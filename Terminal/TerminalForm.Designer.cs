namespace Terminal
{
    partial class TerminalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalForm));
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.TitleBarButtons = new System.Windows.Forms.Panel();
            this.GoToTaskbarButton = new System.Windows.Forms.Button();
            this.MaximiniButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.TitleBarLabel = new System.Windows.Forms.Label();
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripFormStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStripSubroutineStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.TitleBar.SuspendLayout();
            this.TitleBarButtons.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputBox
            // 
            this.outputBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.outputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.outputBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.outputBox.HideSelection = false;
            this.outputBox.Location = new System.Drawing.Point(0, 16);
            this.outputBox.Margin = new System.Windows.Forms.Padding(0);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(740, 274);
            this.outputBox.TabIndex = 1;
            this.outputBox.TabStop = false;
            this.outputBox.Text = "";
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.TitleBar);
            this.splitContainer.Panel1.Controls.Add(this.outputBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.inputBox);
            this.splitContainer.Size = new System.Drawing.Size(740, 318);
            this.splitContainer.SplitterDistance = 290;
            this.splitContainer.SplitterWidth = 3;
            this.splitContainer.TabIndex = 3;
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.TitleBar.Controls.Add(this.TitleBarButtons);
            this.TitleBar.Controls.Add(this.TitleBarLabel);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(740, 16);
            this.TitleBar.TabIndex = 2;
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.TitleBar.Resize += new System.EventHandler(this.UpperBar_Resize);
            // 
            // TitleBarButtons
            // 
            this.TitleBarButtons.Controls.Add(this.GoToTaskbarButton);
            this.TitleBarButtons.Controls.Add(this.MaximiniButton);
            this.TitleBarButtons.Controls.Add(this.ExitButton);
            this.TitleBarButtons.Location = new System.Drawing.Point(692, 0);
            this.TitleBarButtons.Margin = new System.Windows.Forms.Padding(0);
            this.TitleBarButtons.Name = "TitleBarButtons";
            this.TitleBarButtons.Size = new System.Drawing.Size(48, 16);
            this.TitleBarButtons.TabIndex = 3;
            // 
            // GoToTaskbarButton
            // 
            this.GoToTaskbarButton.BackColor = System.Drawing.Color.SlateBlue;
            this.GoToTaskbarButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GoToTaskbarButton.Location = new System.Drawing.Point(0, 0);
            this.GoToTaskbarButton.Margin = new System.Windows.Forms.Padding(0);
            this.GoToTaskbarButton.Name = "GoToTaskbarButton";
            this.GoToTaskbarButton.Size = new System.Drawing.Size(16, 16);
            this.GoToTaskbarButton.TabIndex = 2;
            this.GoToTaskbarButton.UseVisualStyleBackColor = false;
            this.GoToTaskbarButton.Click += new System.EventHandler(this.GoToTaskbarButton_Click);
            this.GoToTaskbarButton.MouseHover += new System.EventHandler(this.GoToTaskbarButton_MouseHover);
            // 
            // MaximiniButton
            // 
            this.MaximiniButton.BackColor = System.Drawing.Color.OliveDrab;
            this.MaximiniButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MaximiniButton.Location = new System.Drawing.Point(16, 0);
            this.MaximiniButton.Margin = new System.Windows.Forms.Padding(0);
            this.MaximiniButton.Name = "MaximiniButton";
            this.MaximiniButton.Size = new System.Drawing.Size(16, 16);
            this.MaximiniButton.TabIndex = 2;
            this.MaximiniButton.UseVisualStyleBackColor = false;
            this.MaximiniButton.Click += new System.EventHandler(this.MaximiniButton_Click);
            this.MaximiniButton.MouseHover += new System.EventHandler(this.MaximiniButton_MouseHover);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Firebrick;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Location = new System.Drawing.Point(32, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(16, 16);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitApplication);
            this.ExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // TitleBarLabel
            // 
            this.TitleBarLabel.AutoSize = true;
            this.TitleBarLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBarLabel.ForeColor = System.Drawing.Color.Silver;
            this.TitleBarLabel.Location = new System.Drawing.Point(302, 1);
            this.TitleBarLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TitleBarLabel.Name = "TitleBarLabel";
            this.TitleBarLabel.Size = new System.Drawing.Size(103, 15);
            this.TitleBarLabel.TabIndex = 2;
            this.TitleBarLabel.Text = "terminal  {version}";
            this.TitleBarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputBox
            // 
            this.inputBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputBox.DetectUrls = false;
            this.inputBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputBox.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.ForeColor = System.Drawing.Color.LawnGreen;
            this.inputBox.Location = new System.Drawing.Point(0, 0);
            this.inputBox.Margin = new System.Windows.Forms.Padding(0);
            this.inputBox.Multiline = false;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(740, 25);
            this.inputBox.TabIndex = 0;
            this.inputBox.TabStop = false;
            this.inputBox.Text = "";
            this.inputBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputBox_KeyDown);
            // 
            // StatusStrip
            // 
            this.StatusStrip.AllowMerge = false;
            this.StatusStrip.BackColor = System.Drawing.Color.DarkSlateGray;
            this.StatusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StatusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripFormStatus,
            this.toolStripDropDownButton1,
            this.StatusStripSubroutineStatus});
            this.StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(740, 22);
            this.StatusStrip.SizingGrip = false;
            this.StatusStrip.TabIndex = 2;
            this.StatusStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // StatusStripFormStatus
            // 
            this.StatusStripFormStatus.ForeColor = System.Drawing.Color.Silver;
            this.StatusStripFormStatus.Image = global::Terminal.Properties.Resources.kisspng_computer_icons_computer_terminal_command_5ae16a50611156_2269332715247222563976;
            this.StatusStripFormStatus.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.StatusStripFormStatus.Name = "StatusStripFormStatus";
            this.StatusStripFormStatus.Size = new System.Drawing.Size(72, 17);
            this.StatusStripFormStatus.Text = "\\terminal";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Silver;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(81, 20);
            this.toolStripDropDownButton1.Text = "Application";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+H";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitApplication);
            // 
            // StatusStripSubroutineStatus
            // 
            this.StatusStripSubroutineStatus.ForeColor = System.Drawing.Color.Silver;
            this.StatusStripSubroutineStatus.Name = "StatusStripSubroutineStatus";
            this.StatusStripSubroutineStatus.Size = new System.Drawing.Size(0, 17);
            this.StatusStripSubroutineStatus.Spring = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(740, 318);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(740, 340);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // TerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(740, 340);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TerminalForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "terminal";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TerminalForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TerminalForm_KeyPress);
            this.Resize += new System.EventHandler(this.TerminalForm_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.TitleBarButtons.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.RichTextBox inputBox;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel StatusStripFormStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MaximiniButton;
        private System.Windows.Forms.Label TitleBarLabel;
        private System.Windows.Forms.Button GoToTaskbarButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel TitleBarButtons;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripSubroutineStatus;
        public System.Windows.Forms.RichTextBox outputBox;
    }
}

