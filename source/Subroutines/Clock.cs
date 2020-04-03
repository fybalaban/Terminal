namespace Terminal.Subroutines
{
    public class Clock : Subroutine
    {
        public new const string SubroutineName = @"clk";
        public Clock(Interpreter parent, string subroutineName) : base(parent, subroutineName)
        {

        }

        public override void ExecuteCommand(string command, string[] arguments)
        {
            base.ExecuteCommand(command, arguments);
        }

        public override void GetCommand(string input)
        {
            base.GetCommand(input);
        }

        public override void StartSubroutine()
        {
            base.StartSubroutine();
        }

        public override void StopSubroutine()
        {
            base.StopSubroutine();
        }
    }
}
