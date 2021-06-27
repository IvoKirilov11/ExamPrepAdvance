using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> lillys = new Stack<int>(Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int wreaths = 0;
            int flowrs = 0;

            while (roses.Count > 0 && lillys.Count > 0)
            {
                int lilly = lillys.Pop();
                int rose = roses.Dequeue();
                
                while (true)
                {
                   int sum = lilly + rose;
                    
                    if(sum == 15)
                   {
                        wreaths++;
                        break;
                   }
                    else if(sum < 15)
                    {
                         flowrs += sum;
                        break;
                    }
                    else
                    {
                        lilly -= 2;
                    
                    }
                }
                
            }

            wreaths += flowrs / 15;
            if(wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }
        }
    }
}
