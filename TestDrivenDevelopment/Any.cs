using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrivenDevelopmentTarget;

namespace TestDrivenDevelopment
{
    public static class Any
    {
        private static readonly Random Random = new Random();

        public static Register Register()
        {
            return Register(Random.Next(int.MaxValue - 1));
        }

        public static Register Register(int value)
        {
            return new Register(Guid.NewGuid().ToString(), value);
        }
    }
}
