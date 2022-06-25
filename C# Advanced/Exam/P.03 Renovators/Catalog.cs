using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> renovators = new List<Renovator>();

        private string name;
        private int neededRenovators;
        private string project;
        public string Name 
        {
            get { return name; }
            set { name = value; } 
        }
        public int NeededRenovators 
        {
            get { return neededRenovators; }
            set { neededRenovators = value; } 
        }
        public string Project 
        {
            get { return project; }
            set { project = value; }
        }

        public int Count
        {
            get { return renovators.Count; }
        }

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        
        public string AddRenovator(Renovator renovator)
        {
            if(string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (NeededRenovators <= renovators.Count) 
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            int index = renovators.FindIndex(x => x.Name == name);

            
            if (index >= 0)
            {
                renovators.RemoveAt(index);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;

            count = renovators.RemoveAll(x => x.Type == type);

            return count;
        }

        public Renovator HireRenovator(string name)
        {

            int index = renovators.FindIndex(x => x.Name == name);
            if (index >= 0)
            {
                Renovator currRen = renovators.Find(x => x.Name == name);
                renovators[index].Hired = true;
                return currRen;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            List<Renovator> freerenovators = renovators.Where(x => x.Hired == false).ToList();

            StringBuilder output = new StringBuilder();

            output.AppendLine($"Renovators available for Project {Project}:");          
            
            foreach(var ren in freerenovators)
            {
                output.AppendLine(ren.ToString());
            }

            return output.ToString();
        }
    }
}
