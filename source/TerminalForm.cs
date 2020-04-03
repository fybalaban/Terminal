using System;
using System.Drawing;
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
            TitleBarLabel.Text = string.Format("terminal {0}", Interpreter.Version);
            Flow flow = new Flow(inputBox, outputBox);
            i = new Interpreter(this, flow);
            i.Start();
        }

        public void ExitApplication(object sender, EventArgs e)
        {
            this.Close();
        }

        private int currentIndex = -1;
        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(inputBox.Text) == false && string.IsNullOrWhiteSpace(inputBox.Text) == false)
                {
                    i.GetCommand();
                    inputBox.Clear();
                    currentIndex = -1;
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.LockAndSleep(15);
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (currentIndex == -1)
                {
                    currentIndex = i.InputHistory.Count - 1;
                }
                else if (currentIndex != 0)
                {
                    currentIndex--;
                }
                if (currentIndex != -1)
                {
                    inputBox.Text = i.InputHistory[currentIndex];
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (currentIndex != i.InputHistory.Count - 1 && currentIndex >= 0)
                {
                    currentIndex++;
                    inputBox.Text = i.InputHistory[currentIndex];
                }
            }
        }

        public void UpdateFormStatusTitle(string newTitle)
        {
            StatusStripFormStatus.Text = newTitle;
            Text = newTitle;
        }

        public void UpdateSubroutineStatusTitle(string newTitle)
        {
            StatusStripSubroutineStatus.Text = newTitle;
        }

        public void LockAndSleep(int mss)
        {
            Thread.Sleep(mss);
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Clicks < 2)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            else if (e.Button == MouseButtons.Left && e.Clicks >= 2)
            {
                if (WindowState != FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void GoToTaskbarButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MaximiniButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Close", ExitButton);
        }

        private void UpperBar_Resize(object sender, EventArgs e)
        {
            TitleBarLabel.Location = new Point(TitleBar.Width / 2, 1);
            TitleBarButtons.Location = new Point(TitleBar.Width - 48, 0);
        }

        private void TerminalForm_Resize(object sender, EventArgs e)
        {
            TitleBar.Size = new Size(Size.Width, 16);
            outputBox.Size = new Size(Width, Height - 67);
            outputBox.Location = new Point(0, 17);
        }

        private void MaximiniButton_MouseHover(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Maximized)
            {
                toolTip.Show("Maximize", MaximiniButton);
            }
            else
            {
                toolTip.Show("Restore down", MaximiniButton);
            }
        }

        private void GoToTaskbarButton_MouseHover(object sender, EventArgs e)
        {
            toolTip.Show("Minimize", GoToTaskbarButton);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputBox.Text = "help\n";
            i.GetCommand();
            inputBox.Clear();
            this.LockAndSleep(15);
        }

        private void TerminalForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TerminalForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled == true)
            {
                if (e.Control == true && e.KeyCode == Keys.E)
                {
                    this.ExitApplication(this, new EventArgs());
                }
                else if (e.Control == true && e.KeyCode == Keys.H)
                {
                    this.helpToolStripMenuItem_Click(this, new EventArgs());
                }
                else if (e.Control == true && e.KeyCode == Keys.O)
                {

                }
            }
        }
    }
}