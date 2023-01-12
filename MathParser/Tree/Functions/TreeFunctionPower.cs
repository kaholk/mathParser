using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    internal class TreeFunctionPower : Tree
    {
        private Tree number;
        private Tree power;

        public TreeFunctionPower(Tree number, Tree power)
        {
            this.number = number;
            this.power = power;
        }

        public override double GetValue()
        {
            return Math.Pow(number.GetValue(), power.GetValue());
        }

        public override string ToString()
        {
            return $"POW({number};{power})";
        }
    }
}
