using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    internal class TreeFunctionAbs : Tree
    {
        private Tree number;

        public TreeFunctionAbs(Tree number)
        {
            this.number = number;
        }

        public override double GetValue()
        {
            return Math.Abs(number.GetValue());
        }

        public override string ToString()
        {
            return $"ABS({number})";
        }
    }
}
