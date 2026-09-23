namespace CoffeeMachine.Services
{
    internal class CoffeeMachineEventArgs : EventArgs
    {
        public CoffeeMachineEventArgs(string stageName, int progressPercentage)
        {
            StageName = stageName;
            ProgressPercentage = progressPercentage;
        }

        public DateTime TimeStamp { get; } = DateTime.Now;

        public string StageName { get; }

        public int ProgressPercentage { get; }
    }
}
