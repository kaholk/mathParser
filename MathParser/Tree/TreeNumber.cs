using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class TreeNumber : Tree
    {
        private double value;

        public TreeNumber(Double value)
        {
            this.value = value;
        }

        public override double GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return $"{this.value}";
        }
    }
}
