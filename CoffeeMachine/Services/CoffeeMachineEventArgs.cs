using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Services
{
    internal class CoffeeMachineEventArgs : EventArgs
    {
        public DateTime TimeStamp { get; } = DateTime.Now;

        public string StageName { get; }

        public int ProgressPercentage { get; }

        public CoffeeMachineEventArgs(string stageName, int progressPercentage)
        {
            StageName = stageName;
            ProgressPercentage = progressPercentage;
        }
    }
}
