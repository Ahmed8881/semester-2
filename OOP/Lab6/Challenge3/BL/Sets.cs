using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    internal class Sets
    {
        
            private float Weight;
            private int Reps;
            public Sets() { }
            public Sets(float weight, int reps)
            {
                this.Weight = weight;
                this.Reps = reps;
            }
            public void SetWeight(float weight)
            {
                this.Weight = weight;
            }
            public float GetWeight()
            {
                return this.Weight;
            }
            public void SetReps(int reps)
            {
                this.Reps = reps;
            }
            public int GetReps()
            {
                return this.Reps;
            }

        }
    }
 
