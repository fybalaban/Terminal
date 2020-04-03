using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Terminal.Subroutines
{
    public class ConsoleBasedTextEditor : Subroutine
    {
        public new const string SubroutineName = @"sanic";
        public const string Version = @"build-1.0";
        private readonly string CommandsExplained = string.Format("help: shows this message\n" +
                                                                  "open \"filename\": opens given file \n" +
                                                                  "openfd: opens file dialog to select a file\n" +
                                                                  "new \"filename\": creates a new file with given filename in working directory\n" +
                                                                  "save: saves open document file\n" +
                                                                  "edit: toggles read-only mode on and off for generic output window\n" +
                                                                  "quit: quits sanic v {0}\n" +
                                                                  "close: closes open document WITHOUT saving\n\n", Version
                                                                  );

        private readonly string Splash = string.Format("00000000000000000000000000000000000000000000000000\n" +
                                                       "0                                                0\n" +
                                                       "0   sanic on terminal     written by fybalaban   0\n" +
                                                       "0                                 ver {0}  0\n" +
                                                       "0                                                0\n" +
                                                       "00000000000000000000000000000000000000000000000000\n\n", Version
                                                       );

        #region Subroutine Controls
        public ConsoleBasedTextEditor(Interpreter parent, string subroutineName) : base(parent, subroutineName)
        {
            Parent.Parent.outputBox.TextChanged += new EventHandler(this.TextChanged);
        }

        public override void StartSubroutine()
        {
            Parent.TakeControl(SubroutineName, this);
            Parent.PassCommand(SubroutineName, "fcls");
            Parent.PassCommand(SubroutineName, "say", new string[1] { Splash });
            Parent.PassCommand(SubroutineName, "wait", new string[1] { "500" });
            Parent.PassCommand(SubroutineName, "say", new string[1] { CommandsExplained });
        }

        public override void GetCommand(string input)
        {
            //girişi düzenler
            string inputRaw = input.Replace("\n", string.Empty).Trim();

            //---------------------------------------girişi yorumlar-------------------------------------------//
            string command;
            string[] arguments = null;

            //girişi parçalarına böl ve segmentlere yerleştir
            if (inputRaw.Contains(" "))
            {
                string[] allWords = inputRaw.Split(' ');
                command = allWords[0];
                arguments = new string[16];
                Interpreter.RemoveAt<string>(ref allWords, 0);
                allWords.CopyTo(arguments, 0);
            }
            else
            {
                command = inputRaw;
            }

            //girilen kelimeleri tanımla
            if (arguments == null)
            {
                bool commandIsValid = CheckForMatch(command, commands);
                if (commandIsValid)
                {
                    this.ExecuteCommand(command, arguments);
                }
                else
                {
                    //girilen dizi hatalı
                    Parent.PassCommand(SubroutineName, "say", new string[1] { string.Format("\nsanic does not recognize >> \"{0}\".\n", command) });
                }
            }
            else
            {
                bool commandIsValid = CheckForMatch(command, commands);
                if (commandIsValid)
                {
                    this.ExecuteCommand(command, arguments);
                }
            }
        }

        public override void ExecuteCommand(string command, string[] arguments)
        {
            switch (command)
            {
                case "quit":
                    Parent.Generic.Output.ReadOnly = true;
                    Parent.PassCommand(SubroutineName, "fcls");
                    Parent.ReleaseControl(SubroutineName);
                    break;

                case "help":
                    Parent.PassCommand(SubroutineName, "say", new string[1] { CommandsExplained });
                    break;

                case "openfd":
                    OpenFileDialog ofd = new OpenFileDialog
                    {
                        Filter = "Text files|*.txt|All files|*.*",
                        InitialDirectory = Environment.CurrentDirectory,
                        DefaultExt = "*.txt"
                    };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        //AÇILACAK
                        this.OpenFile(ofd.FileName);
                    }
                    break;

                case "open":
                    CurrentFileDirectory = arguments[0];
                    if (arguments != null && arguments[0] != null)
                    {
                        if (File.Exists(CurrentFileDirectory))
                        {
                            this.OpenFile(CurrentFileDirectory);
                        }
                        else
                        {
                            Parent.PassCommand(SubroutineName, "say", new string[1] { string.Format("sanic: File to open \"{0}\" does not exist.\n", arguments[0]) });
                        }
                    }
                    else
                    {
                        Parent.PassCommand(SubroutineName, "say", new string[1] { string.Format("sanic: command \"open\" takes 0 arguments for arg0. waited a directory to open.\n") });
                    }
                    break;

                case "save":
                    this.SaveFile();
                    break;

                case "new":
                    if (arguments != null && string.IsNullOrEmpty(arguments[0]) == false && string.IsNullOrWhiteSpace(arguments[0]) == false)
                    {
                        try
                        {
                            File.CreateText(string.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, arguments[0]));
                            Parent.PassCommand(SubroutineName, "fcls");
                            Parent.Generic.Output.ReadOnly = false;
                        }
                        catch (Exception err)
                        {
                            Parent.PassCommand(SubroutineName, "say",
                            new string[1] { string.Format("sanic: Could not create file \"{0}\" in \"{1}\". Error: {2}\n",
                            arguments[0], AppDomain.CurrentDomain.BaseDirectory, err.ToString()) });
                        }
                    }
                    break;

                case "edit":
                    if (CurrentFileDirectory != string.Empty)
                    {
                        if (Parent.Generic.Output.ReadOnly == false) //eğer --read--write
                        {
                            Parent.Generic.Output.ReadOnly = true;
                            string currentStatus = Parent.Parent.StatusStripFormStatus.Text;
                            Parent.Parent.UpdateFormStatusTitle(currentStatus.Replace("--write", string.Empty));
                        }
                        else //eğer --read
                        {
                            Parent.Generic.Output.ReadOnly = false;
                            string currentStatus = Parent.Parent.StatusStripFormStatus.Text;
                            currentStatus += "--write";
                            Parent.Parent.UpdateFormStatusTitle(currentStatus);
                        }
                    }
                    break;
                case "close":
                    if (CurrentFileDirectory != string.Empty)
                    {
                        Parent.PassCommand(SubroutineName, "fcls");
                        Parent.PassCommand(SubroutineName, "say", new string[1] { Splash });
                    }
                    break;
            }
        }
        #endregion

        #region Feature Based Controls
        private string CurrentFileDirectory = string.Empty;

        private void OpenFile(string fileDirectory)
        {
            if (string.IsNullOrEmpty(fileDirectory) == false && string.IsNullOrWhiteSpace(fileDirectory) == false && File.Exists(fileDirectory))
            {
                bool openedSuccessfully = true;
                try
                {
                    List<string> lines = File.ReadAllLines(fileDirectory).ToList();
                    Parent.PassCommand(SubroutineName, "fcls");
                    StringBuilder builder = new StringBuilder();
                    foreach (string item in lines)
                    {
                        builder.AppendLine(item);
                    }
                    Parent.PassCommand(SubroutineName, "say", new string[1] { builder.ToString() });
                }
                catch (Exception err)
                {
                    openedSuccessfully = false;
                    Parent.PassCommand(SubroutineName, "fcls");
                    Parent.PassCommand(SubroutineName, "say", new string[1] { string.Format("sanic: OpenFile(\"{0}\"): An error occured. Error: {1}\n", fileDirectory, err.ToString()) });
                }

                if (openedSuccessfully == true)
                {
                    CurrentFileDirectory = fileDirectory;
                    FileInfo info = new FileInfo(CurrentFileDirectory);
                    Parent.Generic.Output.ReadOnly = false;
                    Parent.Parent.UpdateFormStatusTitle(string.Format("\\terminal\\sanic: {0} --read--write", info.FullName));
                    Parent.Parent.UpdateSubroutineStatusTitle(@" Status: File opened.");
                }
            }
        }

        private void SaveFile()
        {
            bool savedSuccessfully = true;
            if (CurrentFileDirectory != string.Empty)
            {
                try
                {
                    File.WriteAllLines(CurrentFileDirectory, Parent.Generic.Output.Lines.ToList());
                }
                catch (Exception err)
                {
                    savedSuccessfully = false;
                    Parent.PassCommand(SubroutineName, "fcls");
                    Parent.PassCommand(SubroutineName, "say", new string[1] { string.Format("sanic: SaveFile(): An error occured. Error: {0}\n", err.ToString()) });
                }

                if (savedSuccessfully)
                {
                    Parent.Parent.UpdateSubroutineStatusTitle(@" Status: File saved.");
                }
            }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (CurrentFileDirectory != string.Empty)
            {
                Parent.Parent.UpdateSubroutineStatusTitle(string.Format(@" Status: File changed but not saved."));
            }
        }
        #endregion

        private readonly string[] commands = new string[8] { "help", "openfd", "save", "quit", "new", "open", "edit", "close" };
    }
}