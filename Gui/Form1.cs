namespace Gui
{
    public partial class Form1 : Form
    {
        MathParser.Parser parser;
        List<HistoryElement> history = new List<HistoryElement>();

        public Form1()
        {
            InitializeComponent();
            this.parser = new MathParser.Parser();
            this.history = new List<HistoryElement>();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = this.textExpression.Text;
                if(expression.Length > 0)
                {
                    Double resoult = this.parser.Parse(expression);
                    this.labelResult.Text = resoult.ToString();
                    history.Add(new HistoryElement(expression, resoult));
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = this.history;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void insertFunction(string functionName, int paramsCount)
        {
            int indexStart = this.textExpression.SelectionStart;
            int indexEnd = indexStart + this.textExpression.SelectionLength;
            if (this.textExpression.SelectionLength > 1)
            {
                string expresion = this.textExpression.Text.Substring(indexStart, indexEnd - indexStart);
                this.textExpression.Text = this.textExpression.Text.Remove(indexStart, expresion.Length);
                this.textExpression.Text = this.textExpression.Text.Insert(indexStart, $"{functionName}({expresion})");
                this.textExpression.Focus();
                this.textExpression.SelectionLength = 0;
                this.textExpression.SelectionStart = indexStart + expresion.Length + functionName.Length +1;
            }
            else
            {
                this.textExpression.Text = this.textExpression.Text.Insert(indexStart, $"{functionName}()");
                this.textExpression.Focus();
                this.textExpression.SelectionLength = 0;
                this.textExpression.SelectionStart = indexStart + functionName.Length + 1;
            }
        }
        private void buttonAbs_Click(object sender, EventArgs e)
        {
            this.insertFunction("ABS", 1);
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            this.insertFunction("SUM", 1);
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            this.insertFunction("SQRT", 1);
        }

        private void buttonPow_Click(object sender, EventArgs e)
        {
            this.insertFunction("POW", 1);
        }

        private void buttonModulo_Click(object sender, EventArgs e)
        {
            this.insertFunction("MOD", 1);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.textExpression.Text = "";
            this.labelResult.Text = "";
        }


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if(this.dataGridView1.SelectedRows.Count > 0)
                {
                    int index = this.dataGridView1.SelectedRows[0].Index;
                    this.history.RemoveAt(index);
                    this.dataGridView1.DataSource = null;
                    this.dataGridView1.DataSource = this.history;
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }

        private void buttonClearHistory_Click(object sender, EventArgs e)
        {
            this.history.Clear();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = this.history;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int index = this.dataGridView1.SelectedRows[0].Index;
                this.textExpression.Text = this.history[index].Expression;
            }
        }
    }
}