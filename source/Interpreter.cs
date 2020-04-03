using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

using Terminal.Subroutines;

namespace Terminal
{
    public class Interpreter
    {
        public TerminalForm Parent { get; }
        public Flow Generic { get; }
        public const string Version = @"build-1.0";
        public readonly List<string> InputHistory = new List<string>();
        public string TerminalSplash = string.Format("terminal v {0}\n" +
                                                     "written by fybalaban 2020\n" +
                                                     "$" + Environment.MachineName + "@" + Environment.UserName + ": \n\n", Version
                                                     );

        public Interpreter(TerminalForm parent, Flow flow)
        {
            Parent = parent;
            Generic = flow;
            this.FirstRun();
        }

        //---------------------------------------------------------------------------------------------------------//
        #region Interpreter Public Workflow
        private string CurrentSubroutine = CurrentSubroutineEmpty;
        public const string CurrentSubroutineEmpty = @"none";
        private static Subroutine CurrentSubroutineObject;

        public void Start()
        {
            this.FlushCommandBuffer();
            this.WriteOutput(TerminalSplash);
            this.TestInput();
        }

        public void GetCommand()
        {
            this.FlushCommandBuffer();
            string inputRaw = Generic.Input.Text.Replace("\n", string.Empty).Trim();
            InputHistory.Add(inputRaw);
            if (inputRaw.Contains("-h"))
            {
                this.ClearOutput();
                this.WriteOutput(TerminalSplash);
                inputRaw = inputRaw.Replace("-h", string.Empty).Trim();
            }
            if (CurrentSubroutine != CurrentSubroutineEmpty || CurrentSubroutineObject != null || inputRaw.Contains("-q"))
            {
                //girilen komutu çıktı ekranına yazdırmaz.
                inputRaw = inputRaw.Replace("-q", string.Empty).Trim();
                if (string.IsNullOrEmpty(inputRaw) == false && string.IsNullOrWhiteSpace(inputRaw) == false)
                {
                    if (CurrentSubroutine != CurrentSubroutineEmpty)
                    {
                        //eğer şu an aktif çalışan bir başka subroutine varsa girilen metni subroutine'e aktar.
                        CurrentSubroutineObject.GetCommand(inputRaw);
                    }
                    else
                    {
                        this.InterpretCommand(inputRaw);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(inputRaw) == false && string.IsNullOrWhiteSpace(inputRaw) == false)
                {
                    this.WriteOutput(inputRaw + '\n');
                    if (CurrentSubroutine != CurrentSubroutineEmpty)
                    {
                        //eğer şu an aktif çalışan bir başka subroutine varsa girilen metni subroutine'e aktar.
                        CurrentSubroutineObject.GetCommand(inputRaw);
                    }
                    else
                    {
                        this.InterpretCommand(inputRaw);
                    }
                }
            }
        }

        public void TakeControl(string subroutineName, Subroutine subroutine)
        {
            Parent.UpdateFormStatusTitle(string.Format("\\terminal\\{0}", subroutineName));
            CurrentSubroutine = subroutineName;
            CurrentSubroutineObject = subroutine;
        }

        public void ReleaseControl(string subroutineName)
        {
            Parent.UpdateFormStatusTitle(@"\terminal");
            Parent.UpdateSubroutineStatusTitle(@"");
            CurrentSubroutine = "none";
            CurrentSubroutineObject = null;
        }

        public void PassCommand(string subroutineName, string command)
        {
            if (subroutineName == CurrentSubroutine)
            {
                arguments = new string[MAX_ARGUMENTS];
                this.ExecuteCommand(command, arguments);
            }
        }

        public void PassCommand(string subroutineName, string command, string[] arguments)
        {
            if (subroutineName == CurrentSubroutine)
            {
                this.ExecuteCommand(command, arguments);
            }
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------//

        //---------------------------------------------------------------------------------------------------------//
        #region Interpreter Private Workflow
        string command = null;
        string[] arguments = null;

        /// <summary>
        /// Verilen string'i hiçbir değişiklik yapmadan terminalin çıkış ekranına yazar.
        /// </summary>
        /// <param name="buffer">Yazılacak metni bulunduran string değişkeni</param>
        private void WriteOutput(string buffer)
        {
            Generic.Output.AppendText(buffer);
        }

        /// <summary>
        /// GetCommand() metodundan kontrolü alarak verilen giriş string'ini analiz eder, yorumlar ve ExecuteCommand() metoduna kontrolü teslim eder.
        /// </summary>
        /// <param name="commandSequence">Kullanıcı tarafından girilen ham metin bu argümana refere edilerek geçirilir</param>
        private void InterpretCommand(string commandSequence)
        {
            string[] allWords = commandSequence.Split(' ');
            command = allWords[0];
            if (commandSequence == "init") //İSTİSNA BİR: INIT KOMUTU ÖZELDİR VE KULLANICI ULAŞAMAZ
            {
                /*init komutunu yorumlama, TestInput() metodu gerekeni yapacak*/
                command = commandSequence;
            }
            else if (command == "say" && commandSequence.Contains("\""))
            {
                string ax = string.Format(commandSequence.Replace(command, string.Empty).Trim() + '\n');
                arguments = new string[MAX_ARGUMENTS];
                arguments[0] = RemoveWrappers('"', ax);
                this.ExecuteCommand(command, arguments);
            }
            else //KULLANICIDAN GELEN HER KOMUT DİZİSİ BURADA İNCELENİR
            {
                //--------------girişi parçalarına böl ve uygun yerlere yerleştir-------------------------//

                if (commandSequence.Contains(" ")) //eğer giriş boşluklu yapıdaysa bu bir komut ve bir/birden fazla argüman olduğu manasına gelir.
                {
                    arguments = new string[MAX_ARGUMENTS];
                    RemoveAt<string>(ref allWords, 0);
                    allWords.CopyTo(arguments, 0);
                }
                else
                {
                    command = commandSequence;
                    arguments = new string[MAX_ARGUMENTS];
                }

                //girilen komutu tanımla
                bool commandIsValid = this.CheckForMatch(command, AvailableCommands);
                if (!commandIsValid)
                {
                    this.WriteOutput(string.Format("Given terminal input does not contain any command. >> \"{0}\"\n", command));
                }
                else
                {
                    this.ExecuteCommand(command, arguments);
                }
            }
        }

        private void ExecuteCommand(string commandToExecute, string[] argumentsOfCommand)
        {
            switch (commandToExecute)
            {
                case "exit":
                    this.Exit();
                    break;

                case "help":
                    this.Help();
                    break;

                case "clear":
                    this.ClearOutput();
                    string splashLocOnly = TerminalSplash.Split('\n')[2];
                    this.WriteOutput(splashLocOnly);
                    break;

                case "info":
                    break;

                case "sanic":
                    if (argumentsOfCommand[0] == null)
                    {
                        ConsoleBasedTextEditor sub0 = new ConsoleBasedTextEditor(this, "sanic");
                        sub0.StartSubroutine();
                    }
                    break;

                case "say":
                    this.Say(argumentsOfCommand[0]);
                    break;

                case "wait":
                    if (argumentsOfCommand[0] == null)
                    {
                        this.Say("command \"wait\" missing argument 0. arg0 is integer, amount of time to wait in milliseconds\n");
                    }
                    else
                    {
                        Exception error = null;
                        try
                        {
                            Convert.ToInt32(argumentsOfCommand[0]);
                        }
                        catch (Exception err)
                        {
                            error = err;
                            this.Say("command \"wait\" has invalid argument at arg0. type(arg0) = integer. please check your input.\n");
                        }
                        if (error == null)
                        {
                            Thread.Sleep(Convert.ToInt32(argumentsOfCommand[0]));
                        }
                    }
                    break;

                case "keyw":
                    this.WriteOutput("\"-q\": Prevents echoing the command that was entered.\n"
                                    + "\"-h\": Show terminal splash text.\n"
                                    );
                    break;

                case "fcls":
                    this.ClearOutput();
                    break;
            }
        }

        private void TestInput()
        {
            Generic.Input.Text = "init\n";
            this.GetCommand();
            if (command == "init")
            {
                Generic.Input.Clear();
                this.WriteOutput("input test finished successfully. terminal ready to use.\n");
                this.FlushCommandBuffer();
                InputHistory.Remove("init");
            }
        }

        private void FirstRun()
        {
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "firstrun") == false)
            {
                this.ExecuteCommand("say", new string[1] { string.Format("{0}, welcome to terminal v {1}!\n\n" +
                                                                         "This guide will show you how to use terminal.\n" +
                                                                         "The window that you read this text at is called \"generic output window\".\n" +
                                                                         "Below this, there exists the \"generic input window\" where you will enter the commands to control the interpreter.\n" +
                                                                         "To see all the available commands you can use \"help\" command. Have fun!\n\n", Environment.UserName, Version) });
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "firstrun");
            }
        }

        private bool CheckForMatch(string checkThis, string[] inHere)
        {
            bool exists = false;
            foreach (string item in inHere)
            {
                if (checkThis == item)
                {
                    exists = true;
                }
            }
            return exists;
        }

        private void FlushCommandBuffer()
        {
            command = null;
            arguments = null;
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------//

        //---------------------------------------------------------------------------------------------------------//
        #region Interpreter Commands
        private void ClearOutput()
        {
            Generic.Output.Clear();
        }

        private void Exit()
        {
            Parent.ExitApplication(Parent, new EventArgs());
        }

        private void Say(string text)
        {
            this.WriteOutput(text);
        }

        private void Help()
        {
            this.WriteOutput(string.Format("All included commands in terminal v {0}:\n\n" +
                                           "quit: quits terminal, completely halting any ongoing operation.\n" +
                                           "help: shows this message.\n" +
                                           "keyw: shows available command fixes.\n" +
                                           "clear: clears generic output window.\n" +
                                           "wait \"time in milliseconds\": waits for given amount of time.\n" +
                                           "say \"string\": echoes given text. please USE QUOTES around the text you want to print.\n" +
                                           "sanic: start sanic v {1}.\n" +
                                           "info: shows detailed information about terminal.\n", Version, ConsoleBasedTextEditor.Version));
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------//

        private const string INPUT_CHARACTER = @"$:";
        private const int MAX_ARGUMENTS = 16;
        private readonly string[] AvailableCommands = new string[10] { "exit", "clear", "help", "info", "sanic", "say", "keyw", "wait", "clock", "fcls" };

        public static void RemoveAt<T>(ref T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                arr[a] = arr[a + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
        }

        public static string RemoveWrappers(char wrapper, string toBeRemoved)
        {
            string returned = string.Empty;
            if (string.IsNullOrEmpty(toBeRemoved) == false && string.IsNullOrWhiteSpace(toBeRemoved) == false)
            {
                string[] a = toBeRemoved.Split(wrapper);
                returned = a[1];
            }
            return returned;
        }

        public static string ArrayToString(ref string[] arr)
        {
            string returned;
            StringBuilder builder = new StringBuilder();
            foreach (string item in arr)
            {
                builder.Append(item);
            }
            returned = builder.ToString();
            return returned;
        }
    }
}