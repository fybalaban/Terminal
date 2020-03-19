using System;

namespace Terminal
{
    public class Subroutine
    {
        public Interpreter Parent { get; }
        public string SubroutineName { get; }

        public Subroutine(Interpreter parent, string subroutineName)
        {
            Parent = parent;
            SubroutineName = subroutineName;
        }

        public virtual void StartSubroutine()
        {
            Parent.TakeControl(SubroutineName, this);
        }

        public virtual void StopSubroutine()
        {
            Parent.ReleaseControl("sanic");
        }

        /// <summary>
        /// Bu metod herhangi bir Yorumlayıcı/Interpreter tarafından subroutine'e kullanıcı girişini aktaracaktır.
        /// </summary>
        /// <param name="input">Ham, parçalanmamış ve yorumlanmamış metin</param>
        public virtual void GetCommand(string input)
        {
            throw new NotImplementedException($"Subroutine \"{SubroutineName}\" contains a GetCommand() method which was not implemented by the developer.");
        }

        public virtual void ExecuteCommand(string command, string[] arguments)
        {
            throw new NotImplementedException($"Subroutine \"{SubroutineName}\" contains a ExecuteCommand() method which was not implemented by the developer.");
        }

        public static bool CheckForMatch(string checkThis, string[] inHere)
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
    }
}
