using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            string text = "";
            try
            {
                text = File.ReadAllText("help.txt");

            }
            catch (Exception e )
            {
                text = "Bład podczas odczytu z pliku";
            }
            this.textBox1.Text = text;
        }
    }
}
