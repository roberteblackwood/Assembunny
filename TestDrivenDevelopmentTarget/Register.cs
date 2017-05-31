using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenDevelopmentTarget
{
    public class Register
    {
        public Register(string name, int value = 0)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }

        public int Value { get; set; }
    }
}
