using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        List<Employee> data;


        public Bakery(string name,int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        
        public string Name { get; set; }

        public int 	Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if(data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {

            Employee current = data.FirstOrDefault(x => x.Name == name);
            if(current != null)
            {
                data.Remove(current);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(n => n.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return this.data.FirstOrDefault(e => e.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employe in data)
            {
                sb.AppendLine(employe.ToString());
            }
            return sb.ToString().TrimEnd();
        }



    }
}
