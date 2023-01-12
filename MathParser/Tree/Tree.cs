using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class Tree
    {
        public Tree()
        {

        }

        public virtual double GetValue()
        {
            return 0;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
