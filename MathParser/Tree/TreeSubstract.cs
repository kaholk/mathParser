using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class TreeSubstract : Tree
    {
        private Tree treeLeft;
        private Tree treeRight;

        public TreeSubstract(Tree treeLeft, Tree treeRight)
        {
            this.treeLeft = treeLeft;
            this.treeRight = treeRight;
        }

        public override double GetValue()
        {
            return treeLeft.GetValue() - treeRight.GetValue();
        }

        public override string ToString()
        {
            return $"({this.treeLeft}-{this.treeRight})";
        }
    }
}
