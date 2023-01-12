using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class TokenGenerator
    {
        readonly char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        readonly char[] whitespaces = { ' ', '\t', '\n', '\r'};
        readonly char[] numberSeparators = { '.', ',' };
        readonly char[] functionSeparators = { ';' };
        readonly char[] characters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'Q', 'P', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        private CharEnumerator charEnumerator;
        private char? currentChar;
        private List<Token> tokens;

        public TokenGenerator()
        {
            tokens = new List<Token>();
        }

        public List<Token> Generate(string expression)
        {
            this.charEnumerator = expression.GetEnumerator();
            tokens = new List<Token>();
            this.NextChar();
            this.ParseString();
            return tokens;
        }

        private void NextChar()
        {
            if (charEnumerator.MoveNext())
            {
                this.currentChar = charEnumerator.Current;
            }
            else
            {
                this.currentChar = null;
            }
        }

        private void ParseString()
        {
            while (this.currentChar != null)
            {
                char current = (char)this.currentChar;
                if (this.whitespaces.Contains(current))
                    this.NextChar();
                else if (this.numbers.Contains(current))
                    this.ParseNumber();
                else if (this.characters.Contains(current))
                    this.ParseMathFunction();
                else if (this.functionSeparators.Contains(current))
                {
                    this.tokens.Add(new Token(TokenType.FunctionSeparator));
                    this.NextChar();
                }
                else if (current == '+')
                {
                    this.tokens.Add(new Token(TokenType.Plus));
                    this.NextChar();
                }
                else if (current == '-')
                {
                    this.tokens.Add(new Token(TokenType.Minus));
                    this.NextChar();
                }
                else if (current == '*')
                {
                    this.tokens.Add(new Token(TokenType.Multiply));
                    this.NextChar();
                }
                else if (current == '/')
                {
                    this.tokens.Add(new Token(TokenType.Divide));
                    this.NextChar();
                }
                else if (current == '(')
                {
                    this.tokens.Add(new Token(TokenType.LeftBracket));
                    this.NextChar();
                }
                else if (current == ')')
                {
                    this.tokens.Add(new Token(TokenType.RightBracket));
                    this.NextChar();
                }
                else if (current == '^')
                {
                    this.tokens.Add(new Token(TokenType.Power));
                    this.NextChar();
                }
                else
                    throw new Exception($"Nierozopoznany znak {current}");
            }
        }

        private void ParseNumber()
        {
            string numberString = "";
            int numberSeparatorCount = 0;
            while (this.currentChar != null)
            {
                char current = (char)this.currentChar;
                if (!this.numbers.Contains(current) && !this.numberSeparators.Contains(current))
                    break;

                numberString += current;

                if (this.numberSeparators.Contains(current))
                    numberSeparatorCount++;
                this.NextChar();
            }
            if (numberSeparatorCount > 1)
                throw new Exception($"Błąd podczas paarsowania liczby w poblizu {numberString}");

            try
            {
                foreach (char numberSeparator in numberSeparators)
                {
                    numberString = numberString.Replace(numberSeparator, ',');
                } 
                double value = double.Parse(numberString);
                this.tokens.Add(new Token(TokenType.Number, value));
            }
            catch (Exception ex)
            {
                throw new Exception($"Bład podczas konwersji liczby: {ex.Message}");
            }
        }

        private void ParseMathFunction()
        {
            string functionName = "";
            while (this.currentChar != null)
            {
                char current = (char)this.currentChar;
                if (!characters.Contains(current))
                    break;

                functionName += current;
                this.NextChar();
            }

            if (functionName == "POW")
                this.tokens.Add(new Token(TokenType.FunctionPower));
            else if (functionName == "SQRT")
                this.tokens.Add(new Token(TokenType.FunctionSqrt));
            else if (functionName == "ABS")
                this.tokens.Add(new Token(TokenType.FunctionAbs));
            else if (functionName == "MOD")
                this.tokens.Add(new Token(TokenType.FunctionModulo));
            else if (functionName == "SUM")
                this.tokens.Add(new Token(TokenType.FunctionSum));
            else
                throw new Exception($"Nierozpoznana nazwa funkcji ${functionName}");
        }
    }
}
