using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }
        public string Name { get; set; }
        
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Racer racer)
        {
            if(data.Count < Capacity)
            {
                data.Add(racer);
            }
        }
        public bool Remove(string name)
        {
            if(data.Any(x => x.Name == name))
            {
                data.Remove(data.FirstOrDefault(x => x.Name == name));
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Racer GetRacer(string name)
        {
           return data.FirstOrDefault(x => x.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder allRacers = new StringBuilder();
            allRacers.AppendLine($"Racers participating at {Name}:");

            foreach (Racer racers in data)
            {
                allRacers.AppendLine(racers.ToString());
            }
            return allRacers.ToString().TrimEnd();
        }

    }
}
