using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopmentTarget
{
    public class Assembunny
    {
        private readonly IDictionary<string, Register> _registers;

        public Assembunny()
            :this (new Register[] { })
        {
        }

        public Assembunny(Register[] registers)
        {
            this._registers = registers.ToDictionary(register => register.Name, register => register);
        }

        private void Increment(Register register)
        {
            register.Value += 1;
        }

        private void Decrement(Register register)
        {
            register.Value -= 1;
        }

        private void Copy(Register fromRegister, Register toRegister)
        {
            Copy(fromRegister.Value, toRegister);
        }

        private void Copy(int value, Register toRegister)
        {
            toRegister.Value = value;
        }

        public void Execute(string instruction)
        {
            var tokens = instruction.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "cpy":
                    int i;
                    if (int.TryParse(tokens[1], out i))
                    {
                        Copy(i, _registers[tokens[2]]);
                    }
                    else
                    {
                        Copy(_registers[tokens[1]], _registers[tokens[2]]);
                    }
                    break;
                case "inc":
                    Increment(_registers[tokens[1]]);
                    break;
                case "dec":
                    Decrement(_registers[tokens[1]]);
                    break;
            }
        }
    }
}
