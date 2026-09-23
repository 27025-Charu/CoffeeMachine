using CoffeeMachine.Models;

namespace CoffeeMachine.Services
{
    internal class CoffeePreparationService
    {
        private readonly SemaphoreSlim _machineLock = new SemaphoreSlim(1, 1);
        private readonly SemaphoreSlim _pauseGate = new SemaphoreSlim(1, 1);
        private readonly TimerService _timerService = new();
        private readonly PreparationTimeConfig _timeConfig;

        public CoffeePreparationService(TimerService timerservice)
        {
            _timerService = timerservice;
            _timeConfig = new PreparationTimeConfig();
        }

        internal event EventHandler<CoffeeMachineEventArgs> OnPreparation;

        public async Task PreparingCoffeeAsync(Coffee coffee, CancellationToken token)
        {
            if (!await _machineLock.WaitAsync(0))
            {
                throw new InvalidOperationException("The coffee machine is currently busy...");
            }

            try
            {
                var stages = _timeConfig.GetStageDurations(coffee);
                foreach (var stage in stages)
                {
                    token.ThrowIfCancellationRequested();
                    var progressTracker = new Progress<int>(percent =>
                    {
                        var args = new CoffeeMachineEventArgs(stage.Key, percent);
                        OnPreparationStarted(args);
                    });
                }
            }
            finally
            {
                _machineLock.Release();
            }
        }

        protected virtual void OnPreparationStarted(CoffeeMachineEventArgs e)
        {
            this.OnPreparation?.Invoke(this, e);
        }
    }
}
