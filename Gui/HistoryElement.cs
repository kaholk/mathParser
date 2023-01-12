using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui
{
    internal class HistoryElement
    {
        public string Expression { get; set; }
        public double Resoult { get; set; }

        public HistoryElement() { 
        
        }
        public HistoryElement(string expression, double value)
        {
            this.Expression = expression;
            this.Resoult = value;
        }
    }
}
