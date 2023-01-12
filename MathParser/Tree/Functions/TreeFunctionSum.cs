using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    internal class TreeFunctionSum : Tree
    {
        private List<Tree> list;

        public TreeFunctionSum(List<Tree> list)
        {
            this.list = list;
        }

        public override double GetValue()
        {
           return list.Sum(e=>e.GetValue());
        }

        public override string ToString()
        {
            string expresion = string.Join(";",list.Select(e=>e.ToString()));
            return $"SUM({expresion})";
        }
    }
}
