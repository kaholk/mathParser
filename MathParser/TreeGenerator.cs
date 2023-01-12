using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class TreeGenerator
    {
        private List<Token>.Enumerator tokenEnumerator;
        private Token? currentToken;

        public TreeGenerator()
        {
        }

        public Tree Generate(List<Token> tokens)
        {
            if(tokens.Count == 0)
                return new Tree();
            this.tokenEnumerator = tokens.GetEnumerator();
            this.NextToken();
            return this.Calc1();
        }

        public void NextToken()
        {
            if(this.tokenEnumerator.MoveNext())
            {
                this.currentToken = this.tokenEnumerator.Current;
            }
            else
            {
                this.currentToken = null;
            }

        }

        private Tree Calc1()
        {
            Tree resoult = Calc2();
            while(this.currentToken != null)
            {
                if (this.currentToken.type == TokenType.Plus)
                {
                    this.NextToken();
                    return new TreeAdd(resoult, this.Calc2());
                }
                else if(this.currentToken.type == TokenType.Minus)
                {
                    this.NextToken();
                    return new TreeSubstract(resoult, this.Calc2());
                }
                else
                {
                    break;
                }
            }
            return resoult;
        }

        private Tree Calc2()
        {
            Tree resoult = Calc3();
            while (this.currentToken != null)
            {
                if (this.currentToken.type == TokenType.Divide)
                {
                    this.NextToken();
                    return new TreeDivide(resoult, Calc2());
                }
                else if (this.currentToken.type == TokenType.Multiply)
                {
                    this.NextToken();
                    return new TreeMultiply(resoult, Calc2());
                }
                else if (this.currentToken.type == TokenType.Power)
                {
                    this.NextToken();
                    return new TreeFunctionPower(resoult, Calc2());
                }
                else
                {
                    break;
                }
            }
            return resoult;
        }

        private Tree Calc3()
        {
            if (this.currentToken == null)
                throw new Exception("Błąd składni");

            Token current = this.currentToken;

            if(current.type == TokenType.Number)
            {
                this.NextToken();
                if (current.value == null)
                    throw new Exception("Brak wartości dla tokenu Number");
                Double token_value = (Double)current.value;
                return new TreeNumber(token_value);
            }
            else if(current.type == TokenType.LeftBracket)
            {
                this.NextToken();
                Tree resoult = this.Calc1();
                if(this.currentToken.type != TokenType.RightBracket)
                    throw new Exception("Brak nawiasu zamykającego");
                this.NextToken();
                return resoult;
            }
            else if(current.type == TokenType.FunctionPower)
            {
                return FunctionPow();
            }
            else if(current.type == TokenType.FunctionSqrt)
            {
                return FunctionSqrt();
            }
            else if(current.type == TokenType.FunctionAbs)
            {
                return FunctionAbs();
            }
            else if (current.type == TokenType.FunctionModulo)
            {
                return FunctionModulo();
            }
            else if (current.type == TokenType.FunctionSum)
            {
                return FunctionSum();
            }
            else if(current.type == TokenType.Plus)
            {
                this.NextToken();
                return new TreePlus(Calc3());
            }
            else if (current.type == TokenType.Minus)
            {
                this.NextToken();
                return new TreeMinus(Calc3());
            }

            throw new Exception("Bład Składni");
        }

        private Tree FunctionModulo()
        {
            this.NextToken();
            if (this.currentToken.type != TokenType.LeftBracket)
                throw new Exception("Brak nawiasu otwierajacego");
            this.NextToken();
            Tree left = Calc1();
            if (this.currentToken.type != TokenType.FunctionSeparator)
                throw new Exception("Brak spearatora");
            this.NextToken();
            Tree right = Calc1();
            if (this.currentToken.type != TokenType.RightBracket)
                throw new Exception("Brak nawiasu zamykajacego");
            this.NextToken();
            return new TreeFunctionMod(left, right);
        }

        private Tree FunctionSum()
        {
            this.NextToken();
            List<Tree> treeList = new List<Tree>();
            if (this.currentToken.type != TokenType.LeftBracket)
                throw new Exception("Brak nawiasu otwierajacego");
            do
            {
                this.NextToken();
                treeList.Add(Calc1());
            } while (this.currentToken.type == TokenType.FunctionSeparator);

            if (this.currentToken.type != TokenType.RightBracket)
                throw new Exception("Brak nawiasu zamykajacego");
            this.NextToken();
            return new TreeFunctionSum(treeList);
        }

        private Tree FunctionAbs()
        {
            this.NextToken();
            if (this.currentToken.type != TokenType.LeftBracket)
                throw new Exception("Brak nawiasu otwierajacego");
            this.NextToken();
            Tree value = Calc1();
            if (this.currentToken.type != TokenType.RightBracket)
                throw new Exception("Brak nawiasu zamykajacego");
            this.NextToken();
            return new TreeFunctionAbs(value);
        }

        private Tree FunctionSqrt()
        {
            this.NextToken();
            if (this.currentToken.type != TokenType.LeftBracket)
                throw new Exception("Brak nawiasu otwierajacego");
            this.NextToken();
            Tree value = Calc1();
            if (this.currentToken.type != TokenType.RightBracket)
                throw new Exception("Brak nawiasu zamykajacego");
            this.NextToken();
            return new TreeFunctionSqrt(value);
        }

        private Tree FunctionPow()
        {
            this.NextToken();
            if (this.currentToken.type != TokenType.LeftBracket)
                throw new Exception("Brak nawiasu otwierajacego");
            this.NextToken();
            Tree left = Calc1();
            if (this.currentToken.type != TokenType.FunctionSeparator)
                throw new Exception("Brak spearatora");
            this.NextToken();
            Tree right = Calc1();
            if (this.currentToken.type != TokenType.RightBracket)
                throw new Exception("Brak nawiasu zamykajacego");
            this.NextToken();
            return new TreeFunctionPower(left, right);
        }
    }
}
