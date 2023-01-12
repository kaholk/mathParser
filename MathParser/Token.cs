using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public enum TokenType
    {
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        Power,
        LeftBracket,
        RightBracket,
        FunctionSeparator,
        FunctionPower,
        FunctionSqrt,
        FunctionAbs,
        FunctionModulo,
        FunctionSum
    }

    public class Token
    {
        public TokenType type;
        public double? value;

        public Token(TokenType type, double? value = null)
        {
            this.type = type;
            this.value = value;
        }

        public override string ToString()
        {
            if (this.value == null)
                return $"{this.type}";
            else
                return $"{this.type}:{this.value}";
        }
    }
}
