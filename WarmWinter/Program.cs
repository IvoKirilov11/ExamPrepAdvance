using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hats = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> scarfs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            Stack<int> hatsOriginal = new Stack<int>(hats);
            Queue<int> scaftsOriginal = new Queue<int>(scarfs);
            Queue<int> complect = new Queue<int>();

            while (hatsOriginal.Count > 0 && scaftsOriginal.Count > 0)
            {
                int numHat = hatsOriginal.Peek();
                int numScaft = scaftsOriginal.Peek();
                if(numScaft > numHat)
                {
                    hatsOriginal.Pop();
                }
                else if(numScaft < numHat)
                {
                    complect.Enqueue(hatsOriginal.Pop() + scaftsOriginal.Dequeue());
                }
                else if(numHat == numScaft)
                {
                    scaftsOriginal.Dequeue();
                    int[] arr = hatsOriginal.ToArray();
                    arr[0]++;
                    hatsOriginal = new Stack<int>(arr.Reverse());
                }
            }
            Console.WriteLine($"The most expensive set is: {complect.Max()}");
            Console.WriteLine(string.Join(" ", complect));
        }
    }
}
