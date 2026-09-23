using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine.Models.Enums
{
    internal enum MachineStates
    {
        Available = 1,
        Preparing,
        PreparationCompleted,
        PreparationCancelled,
    }
}
