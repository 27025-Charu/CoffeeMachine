using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Models.Enums;

namespace CoffeeMachine.Models
{
    internal class PreparationTimeConfig
    {
        private static readonly Dictionary<CoffeeTypes, TimeSpan> _typePrepTime = new()
        {
            [CoffeeTypes.Espresso] = TimeSpan.FromSeconds(4),
            [CoffeeTypes.Americano] = TimeSpan.FromSeconds(3),
            [CoffeeTypes.Latte] = TimeSpan.FromSeconds(2),
            [CoffeeTypes.Cappuccino] = TimeSpan.FromSeconds(5),
        };

        private static readonly Dictionary<CoffeeStrength, TimeSpan> _strengthprepTime = new()
        {
            [CoffeeStrength.Mild] = TimeSpan.FromSeconds(1),
            [CoffeeStrength.Normal] = TimeSpan.FromSeconds(2),
            [CoffeeStrength.Strong] = TimeSpan.FromSeconds(3),
        };

        private static readonly Dictionary<CoffeeSize, TimeSpan> _sizeprepTime = new()
        {
            [CoffeeSize.Small] = TimeSpan.FromSeconds(1),
            [CoffeeSize.Medium] = TimeSpan.FromSeconds(2),
            [CoffeeSize.Large] = TimeSpan.FromSeconds(3),
        };

        public TimeSpan GetDuration(CoffeeSize size, CoffeeTypes coffeeTypes, CoffeeStrength coffeeStrength)
        {
            TimeSpan totalDuration = TimeSpan.Zero;
            if (_typePrepTime.TryGetValue(coffeeTypes, out TimeSpan typeTime))
            {
                totalDuration += typeTime;
            }

            if (_strengthprepTime.TryGetValue(coffeeStrength, out TimeSpan strengthTime))
            {
                totalDuration += strengthTime;
            }

            if (_sizeprepTime.TryGetValue(size, out TimeSpan sizeTime))
            {
                totalDuration += sizeTime;
            }

            return totalDuration;
        }

        public Dictionary<string, TimeSpan> GetStageDurations(Coffee coffee)
        {
            TimeSpan totalTime = this.GetDuration(coffee.Size, coffee.Name, coffee.Strength);
            List<string> stages = coffee.CoffeePreparationList;
            var stageBreakdown = new Dictionary<string, TimeSpan>();
            if (stages == null || stages.Count == 0)
            {
                return stageBreakdown;
            }

            double msPerStage = totalTime.TotalMilliseconds / stages.Count;
            TimeSpan stageDuration = TimeSpan.FromMilliseconds(msPerStage);
            foreach (var stage in stages)
            {
                stageBreakdown[stage] = stageDuration;
            }

            return stageBreakdown;
        }
    }
}
