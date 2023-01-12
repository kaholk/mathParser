using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    internal class TreeFunctionMod : Tree
    {
        private Tree number;
        private Tree divisor;

        public TreeFunctionMod(Tree number, Tree divisor)
        {
            this.number = number;
            this.divisor = divisor;
        }

        public override double GetValue()
        {
            return number.GetValue() % divisor.GetValue();
        }

        public override string ToString()
        {
            return $"MOD({number},{divisor})";
        }
    }
}
