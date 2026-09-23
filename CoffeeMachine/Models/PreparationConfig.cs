using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Models.Enums;

namespace CoffeeMachine.Models
{
    internal class PreparationConfig
    {
        public List<string> CoffeePreparationConfig(CoffeeTypes coffee)
        {
            switch (coffee)
            {
                case CoffeeTypes.Espresso:
                    return new List<string> { "Grinding", "Heating", "Extraction", "Serving" };
                case CoffeeTypes.Americano:
                    return new List<string> { "Grinding", "Heating", "Extraction", "Mixing", "Serving" };
                case CoffeeTypes.Latte:
                case CoffeeTypes.Cappuccino:
                    return new List<string> { "Grinding", "Heating", "Extraction", "Milk preparation", "Mixing", "Serving" };
                default:
                    throw new ArgumentOutOfRangeException(nameof(coffee), coffee, "Unsupported coffee type.");
            }
        }
    }
}
