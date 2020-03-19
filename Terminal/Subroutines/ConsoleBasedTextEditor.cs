using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Terminal.Subroutines
{
    public class ConsoleBasedTextEditor : Subroutine
    {
        public new const string SubroutineName = @"sanic";

        #region Subroutine Controls
        public ConsoleBasedTextEditor(Interpreter parent, string subroutineName) : base(parent, subroutineName)
        {
        }

        public override void StartSubroutine()
        {
            Parent.TakeControl(SubroutineName, this);
            Parent.PassCommand("sanic", "clear");
            string splash = string.Format("00000000000000000000000000000000000000000000000000\n" +
                                       "0                                                0\n" +
                                       "0   sanic on terminal     written by fybalaban   0\n" +
                                       "0                                 ver dev-0.2    0\n" +
                                       "0                                                0\n" +
                                       "00000000000000000000000000000000000000000000000000\n"
                                       );
            Parent.PassCommand("sanic", "say", new string[1] { splash });
            Parent.PassCommand("sanic", "wait", new string[1] { "750" });
            string commands = string.Format("help: shows this message\n" +
                                            "open \"filename\": opens given file \n" +
                                            "openfd: opens file dialog to select a file\n" +
                                            "new \"filename\": creates a new file with given filename in working directory\n" +
                                            "save: saves open document file\n" +
                                            "quit: quits sanic v dev-0.2\n"
                                            );
            Parent.PassCommand("sanic", "say", new string[1] { commands });
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
                    Parent.PassCommand("sanic", "say", new string[1] { $"\nsanic does not recognize >> \"{command}\".\n" });
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
            switch(command)
            {
                case "quit":
                    Parent.PassCommand("sanic", "clear");
                    Parent.ReleaseControl("sanic");
                    break;
                case "help":
                    string commands = string.Format("help: shows this message\n" +
                                            "open \"filename\": opens given file \n" +
                                            "openfd: opens file dialog to select a file\n" +
                                            "new \"filename\": creates a new file with given filename in working directory\n" +
                                            "save: saves open document file\n" +
                                            "quit: quits sanic v dev-0.2\n"
                                            );
                    Parent.PassCommand("sanic", "say", new string[1] { commands });
                    break;
                case "openfd":
                    var ofd = new OpenFileDialog
                    {
                        Filter = "Text files|*.txt|All files|*.*",
                        InitialDirectory = Environment.CurrentDirectory,
                        DefaultExt = "*.txt"
                    };
                    if (ofd.ShowDialog() == DialogResult.OK) 
                    {
                        //AÇILACAK
                        // ofd.FileName;
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
                try
                {
                    List<string> lines = File.ReadAllLines(fileDirectory).ToList();
                    Parent.PassCommand("sanic", "clear");
                    Parent.PassCommand("sanic", "say", lines.ToArray());
                    Parent.Generic.Output.ReadOnly = false;
                }
                catch (Exception err)
                {
                    Parent.PassCommand("sanic", "clear");
                    Parent.PassCommand("sanic", "say", new string[1] { $"sanic: OpenFile(\"{fileDirectory}\"): An error occured. Error: {err.ToString()}\n" });
                }
            }
        }

        private void SaveFile()
        {
            if (CurrentFileDirectory != string.Empty)
            {
                try
                {
                    File.WriteAllLines(CurrentFileDirectory, Parent.Generic.Input.Lines.ToList());
                }
                catch (Exception err)
                {
                    Parent.PassCommand("sanic", "clear");
                    Parent.PassCommand("sanic", "say", new string[1] { $"sanic: SaveFile(): An error occured. Error: {err.ToString()}\n" });
                }
            }
        }
        #endregion
        
        private readonly string[] commands = new string[6] { "help", "openfd", "save", "quit", "new", "open" };
    }
}