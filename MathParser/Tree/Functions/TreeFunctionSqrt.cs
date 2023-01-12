using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    internal class TreeFunctionSqrt : Tree
    {
        private Tree number;

        public TreeFunctionSqrt(Tree number)
        {
            this.number = number;
        }

        public override double GetValue()
        {
            double numberValue = number.GetValue();
            if (numberValue < 0)
                throw new Exception("Funkcja pierwiastka przyjmuje liczby >= 0");
            return Math.Sqrt(numberValue);
        }

        public override string ToString()
        {
            return $"SQRT({number})";
        }
    }
}
