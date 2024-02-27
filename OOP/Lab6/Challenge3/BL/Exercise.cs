using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    internal class Exercise
    {
        
            private string Name;
            private List<Sets> Sets;
            public Exercise(string name)
            {
                this.Name = name;
                Sets = new List<Sets>();
            }
            public Exercise(string name, List<Sets> sets)
            {
                this.Name = name;
                this.Sets = sets;
            }
            // Copy Constructor
            public Exercise(Exercise exercise)
            {
                this.Name = exercise.Name;
                this.Sets = exercise.Sets;
            }
            public void AddSet(Sets set)
            {
                Sets.Add(set);
            }
            public void RemoveSet(Sets set)
            {
                Sets.Remove(set);
            }
            public string GetName()
            {
                return this.Name;
            }
            public void SetName(string name)
            {
                this.Name = name;
            }
            public List<Sets> GetSets()
            {
                return this.Sets;
            }
            public void SetSets(List<Sets> sets)
            {
                this.Sets = sets;
            }
        }
    }

