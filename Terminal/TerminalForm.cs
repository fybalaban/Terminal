using System;
using System.Threading;
using System.Windows.Forms;

namespace Terminal
{
    public partial class TerminalForm : Form
    {
        public static Interpreter i;

        public TerminalForm()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputBox.Focus();
            Flow flow = new Flow(inputBox, outputBox);
            i = new Interpreter(this, flow);
            i.Start();
        }

        private void inputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(inputBox.Text) == false && string.IsNullOrWhiteSpace(inputBox.Text) == false)
                {
                    i.GetCommand();
                    inputBox.Clear();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                LockAndSleep(15);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LockAndSleep(int mss)
        {
            Thread.Sleep(mss);
        }
    }
}
