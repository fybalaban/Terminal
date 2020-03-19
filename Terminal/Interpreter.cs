using System;
using System.Text;
using System.Threading;

using Terminal.Subroutines;

namespace Terminal
{
    public class Interpreter
    {
        public TerminalForm Parent { get; }
        public Flow Generic { get; }
        public string TerminalSplash = string.Format("terminal v dev-0.4\n" +
                                                     "written by fybalaban 2020\n" +
                                                     "$" + Environment.MachineName + "@" + Environment.UserName + ": \n\n"
                                                     );

        public Interpreter(TerminalForm parent, Flow flow)
        {
            Parent = parent;
            Generic = flow;
        }

        //---------------------------------------------------------------------------------------------------------//
        #region Interpreter Public Workflow
        private string CurrentSubroutine = "none";
        private static Subroutine CurrentSubroutineObject;

        public void Start()
        {
            command = null;
            arguments = null;
            this.WriteOutput(TerminalSplash);
            this.TestInput();
        }

        public void GetCommand()
        {
            string inputRaw = Generic.Input.Text.Replace("\n", string.Empty).Trim();
            if (inputRaw.Contains("-h")) 
            {
                this.ClearOutput();
                this.WriteOutput(TerminalSplash);
                inputRaw = inputRaw.Replace("-h", string.Empty).Trim();
            }
            if (inputRaw.Contains("-q"))
            {
                //girilen komutu çıktı ekranına yazdırmaz.
                inputRaw = inputRaw.Replace("-q", string.Empty).Trim();
                if (string.IsNullOrEmpty(inputRaw) == false && string.IsNullOrWhiteSpace(inputRaw) == false)
                {
                    if (CurrentSubroutine != "none")
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
                    if (CurrentSubroutine != "none")
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
            Parent.Text = string.Format($"terminal - {subroutineName}");
            CurrentSubroutine = subroutineName;
            CurrentSubroutineObject = subroutine;
        }

        public void ReleaseControl(string subroutineName)
        {
            Parent.Text = string.Format($"terminal");
            CurrentSubroutine = "none";
            CurrentSubroutineObject = null;
        }

        public void PassCommand(string subroutineName, string command)
        {
            if (subroutineName == CurrentSubroutine)
            {
                this.ExecuteCommand(command);
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
            Generic.Output.ReadOnly = false;
            StringBuilder builder = new StringBuilder(Generic.Output.Text);
            builder.Append(buffer);
            Generic.Output.Text = builder.ToString();
            Generic.Output.ReadOnly = true;
        }

        private void InterpretCommand(string commandSequence)
        {
            if (commandSequence == "init")
            {
                /*init komutunu yorumlama, TestInput() metodu gerekeni yapacak*/
                command = commandSequence;
            }
            else
            {
                //girişi parçalarına böl ve segmentlere yerleştir
                if (commandSequence.Contains(" "))
                {
                    string[] allWords = commandSequence.Split(' ');
                    command = allWords[0];
                    arguments = new string[16];
                    RemoveAt<string>(ref allWords, 0);
                    allWords.CopyTo(arguments, 0);
                }
                else
                {
                    command = commandSequence;
                }

                //girilen kelimeleri tanımla
                if (arguments == null)
                {
                    bool commandIsValid = this.CheckForMatch(command, commands);
                    if (commandIsValid)
                    {
                        this.ExecuteCommand(command);
                    }
                    else
                    {
                        //girilen dizi hatalı
                        this.WriteOutput($"Given terminal input does not contain any command. >> \"{command}\"\n");
                    }
                }
                else
                {
                    bool commandIsValid = this.CheckForMatch(command, commands);
                    if (commandIsValid)
                    {
                        this.ExecuteCommand(command, arguments);
                    }
                }
            }
        }

        private void ExecuteCommand(string commandToExecute)
        {
            switch (commandToExecute)
            {
                case "exit":
                    this.Exit();
                    break;
                case "help":
                    break;
                case "clear":
                    this.ClearOutput();
                    break;
                case "info":
                    break;
                case "sanic":
                    ConsoleBasedTextEditor sub0 = new ConsoleBasedTextEditor(this, "sanic");
                    sub0.StartSubroutine();
                    break;
                case "say":
                    this.Say(string.Empty);
                    break;
                case "wait":
                    this.Say("command \"wait\" missing argument 0. arg0 is integer, amount of time to wait in milliseconds\n");
                    break;
                case "keyw":
                    this.WriteOutput("\"-q\": Girilen komutun çıktı ekranına tekrar yazdırılmasının önüne geçer.\n"
                                    +"\"-h\": Terminal splash metninin yazdırılmasını sağlar.\n" 
                                    );
                    break;
            }
        }

        private void ExecuteCommand(string commandToExecute, string[] arguments)
        {
            switch (commandToExecute)
            {
                case "exit":
                    this.Exit();
                    break;
                case "help":
                    break;
                case "clear":
                    this.ClearOutput();
                    break;
                case "info":
                    break;
                case "sanic":
                    break;
                case "say":
                    this.Say(arguments[0]);
                    break;
                case "wait":
                    Exception error = null;
                    try
                    {
                        Convert.ToInt32(arguments[0]);
                    }
                    catch (Exception err)
                    {
                        error = err;
                        this.Say("command \"wait\" has invalid argument at arg0. type(arg0) = integer. please check your input.\n");
                    }
                    if (error == null)
                    {
                        Thread.Sleep(Convert.ToInt32(arguments[0]));
                    }
                    break;
            }
        }

        private void TestInput()
        {
            //Generic.Input.Text = "pc/fybalaban/ $:init\n";
            Generic.Input.Text = "init\n";
            this.GetCommand();
            if (command == "init")
            {
                Generic.Input.Clear();
                this.WriteOutput("input test finished successfully. terminal ready to use.\n");
                this.FlushCommandBuffer();
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
            Parent.Close();
        }

        private void Say(string text)
        {
            this.WriteOutput(text);
        }
        #endregion
        //---------------------------------------------------------------------------------------------------------//

        const string INPUT_CHARACTER = @"$:";
        private readonly string[] commands = new string[8] { "exit", "clear", "help", "info", "sanic", "say", "keyw", "wait" };

        public static void RemoveAt<T>(ref T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                arr[a] = arr[a + 1];
            }
            Array.Resize(ref arr, arr.Length - 1);
        }
    }
}