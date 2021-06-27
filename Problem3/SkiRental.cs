using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        List<Ski> data;

        public SkiRental(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }
        
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Ski ski)
        {
            if (data.Count < Capacity)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski skiRemove = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (skiRemove != null)
            {
                data.Remove(skiRemove);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if(data.Count > 0)
            {
              return data.OrderByDescending(c => c.Year).FirstOrDefault();
            }
            return null;
            
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return ski;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
