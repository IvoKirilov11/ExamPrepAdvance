using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int>effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());
            Stack<int> cases = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int datura = 0;
            int cherry = 0;
            int smoke = 0;

            int decrease = 0;

            while (effects.Count > 0 && cases.Count > 0)
            {
                if(datura >= 3 && cherry >= 3 && smoke >= 3)
                {
                    break;
                }
                
                
                int currEffect = effects.Peek();
                int currCases = cases.Peek() - decrease;

                
                int combineit = currCases + currEffect;
                bool bombCreate = false;

                if(combineit == 40)
                {
                    datura++;
                    bombCreate = true;
                }
                else if(combineit == 60)
                {
                    cherry++;
                    bombCreate = true;
                }
                else if(combineit == 120)
                {
                    smoke++;
                    bombCreate = true;
                }

                if(bombCreate)
                {
                    effects.Dequeue();
                    cases.Pop();
                    decrease = 0;
                }
                else if(currCases <= 0)
                {
                    cases.Pop();
                    decrease = 0;
                }
                else
                {
                    decrease += 5;
                }
            }

            if (datura >= 3 && cherry >= 3 && smoke >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if(effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effects)}");
            }
            if (cases.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", cases)}");
            }

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");


        }
    }
}
