using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray());

            int dippingSauce = 0;
            int greenSalad = 0;
            int chocolateCake = 0;
            int lobster = 0;

            while (ingredients.Count != 0 && freshness.Count != 0)
            {
                int stakElement = freshness.Pop();
                int sum = ingredients.Dequeue() * stakElement;

                switch (sum)
                {
                    case 150:
                        dippingSauce++;
                        break;
                    case 250:
                        greenSalad++;
                        break;
                    case 300:
                        chocolateCake++;
                        break;
                    case 400:
                        lobster++;
                        break;
                    default:
                        freshness.Push(stakElement + 5);
                        break;
                }
            }
            OutputPrinter(ingredients, freshness, dippingSauce, greenSalad, chocolateCake, lobster);
        }

        private static void OutputPrinter(Queue<int> ingredients, Stack<int> freshness, int dippingSauce, int greenSalad, int chocolateCake, int lobster)
        {
            if((dippingSauce > 0) && (greenSalad > 0) && (chocolateCake > 0) && (lobster > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            
            
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            if(chocolateCake > 0)
            {
               Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
            }
            if (dippingSauce > 0)
            {
              Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
            }
            if(greenSalad > 0)
            {
              Console.WriteLine($"# Green salad --> {greenSalad}");
            }
            if(lobster > 0)
            {

              Console.WriteLine($"# Lobster: --> {lobster}");
            }
            
            
            
        }
    }
}
