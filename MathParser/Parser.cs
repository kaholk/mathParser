using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class Parser
    {
        private TokenGenerator tokenGenerator;
        private TreeGenerator treeGenerator;
        List<Token> tokens;
        Tree tree;

        public Parser()
        {
            this.tokenGenerator = new TokenGenerator();
            this.treeGenerator = new TreeGenerator();
            this.tokens = new List<Token>();
        }

        public Double Parse(string expresion)
        {
            this.tokens = tokenGenerator.Generate(expresion);
            this.tree = this.treeGenerator.Generate(tokens);
            
            return this.tree.GetValue();
        }
    }
}
