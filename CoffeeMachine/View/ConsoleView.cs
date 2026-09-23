using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CoffeeMachine.Models;
using CoffeeMachine.Models.Enums;

namespace CoffeeMachine.View
{
    internal class ConsoleView
    {
        public void Run()
        {
            CoffeeTypes type = this.UserInputCoffeeType();
            if (type == CoffeeTypes.None)
            {
                this.ExitApplication();
                return;
            }

            Console.Clear();
            CoffeeSize size = this.UserInputCoffeeSize();
            if (size == CoffeeSize.None)
            {
                this.ExitApplication();
                return;
            }

            Console.Clear();
            CoffeeStrength strength = this.UserInputCoffeeStrength();
            if (strength == CoffeeStrength.None)
            {
                this.ExitApplication();
                return;
            }

            Console.Clear();
            Coffee coffee = new ()
            {
                Size = size,
                Strength = strength,
                Name = type,
            };
            Console.WriteLine($"\nStarting preparation for {coffee.Name}...");
            foreach (var step in coffee.CoffeePreparationList)
            {
                Console.WriteLine($" -> {step}...");
            }

            Console.WriteLine("Your coffee is ready! Enjoy!");
            Console.ReadKey();
        }

        private CoffeeStrength UserInputCoffeeStrength()
        {
            Console.WriteLine(@"COFFEE STRENGTH
[M] MILD
[N] NORMAL
[S] STRONG
[X] CANCEL OPERATION");
            while (true)
            {
                Console.WriteLine("Enter the Coffee strength you prefer:");
                ConsoleKeyInfo key = Console.ReadKey(true);
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.M:
                        return CoffeeStrength.Mild;
                    case ConsoleKey.N:
                        return CoffeeStrength.Normal;
                    case ConsoleKey.S:
                        return CoffeeStrength.Strong;
                    case ConsoleKey.X:
                        return CoffeeStrength.None;
                    default:
                        Console.WriteLine("Invalid key. Enter a valid key[M or N or S or X] :");
                        continue;
                }
            }
        }

        private CoffeeSize UserInputCoffeeSize()
        {
            Console.WriteLine(@"COFFEE SIZE:
[S] SMALL
[M] MEDIUM
[L] LARGE
[X] CANCEL OPERATION");
            while (true)
            {
                Console.WriteLine("Enter the Coffee size you prefer:");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.S:
                        return CoffeeSize.Small;
                    case ConsoleKey.M:
                        return CoffeeSize.Medium;
                    case ConsoleKey.L:
                        return CoffeeSize.Large;
                    case ConsoleKey.X:
                        Console.WriteLine("Cancelling the order halfway....");
                        return CoffeeSize.None;
                    default:
                        Console.WriteLine("Invalid key. Enter a valid key[S or M or L or X] :");
                        continue;
                }
            }
        }

        private void ExitApplication()
        {
            Console.WriteLine("Exiting the coffee machine application...");
        }

        private CoffeeTypes UserInputCoffeeType()
        {
            Console.WriteLine(@"COFFEE TYPE:
[E] ESPRESSO
[A] AMERICANO
[C] CAPPUCCINO
[L] LATTE
[X] CANCEL OPERATION");
            while (true)
            {
                Console.WriteLine("Enter the Coffee type you prefer:");
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        return CoffeeTypes.Espresso;
                    case ConsoleKey.A:
                        return CoffeeTypes.Americano;
                    case ConsoleKey.C:
                        return CoffeeTypes.Cappuccino;
                    case ConsoleKey.L:
                        return CoffeeTypes.Latte;
                    case ConsoleKey.X:
                        Console.WriteLine("Cancelling the order halfway....");
                        return CoffeeTypes.None;
                    default:
                        Console.WriteLine("Invalid key. Enter a valid key[E or A or C or L or X] :");
                        continue;
                }
            }
        }
    }
}
