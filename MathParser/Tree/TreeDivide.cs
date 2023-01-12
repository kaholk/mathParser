using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class TreeDivide : Tree
    {
        private Tree treeLeft;
        private Tree treeRight;

        public TreeDivide(Tree treeLeft, Tree treeRight)
        {
            this.treeLeft = treeLeft;
            this.treeRight = treeRight;
        }

        public override double GetValue()
        {
            Double right = treeRight.GetValue();
            if (right == 0)
                throw new Exception("Nie można dzielić przez zero");

            Double left = treeLeft.GetValue();
            return left / right;
        }

        public override string ToString()
        {
            return $"({this.treeLeft}/{this.treeRight})";
        }
    }
}
