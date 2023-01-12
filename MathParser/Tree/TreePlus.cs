﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class TreePlus : Tree
    {
        private Tree tree;

        public TreePlus(Tree tree)
        {
            this.tree = tree;
        }

        public override double GetValue()
        {
            return tree.GetValue();
        }

        public override string ToString()
        {
            return $"(+{this.tree})";
        }
    }
}
