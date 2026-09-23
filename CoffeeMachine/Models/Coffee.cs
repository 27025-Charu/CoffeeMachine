using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Models;
using CoffeeMachine.Models.Enums;

namespace CoffeeMachine.Models
{
    internal class Coffee
    {
        private readonly PreparationConfig _config = new PreparationConfig();

        public CoffeeTypes Name { get; set; }

        public CoffeeSize Size { get; set; }

        public CoffeeStrength Strength { get; set; }

        public List<string> CoffeePreparationList
        {
            get
            {
                return this._config.CoffeePreparationConfig(this.Name);
            }
        }
    }
}
