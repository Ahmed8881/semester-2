using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    internal class WorkOutRoutine
    {
       
            private string Name;
            private List<Exercise> Exercises;
            public WorkOutRoutine(string name)
            {
                this.Name = name;
                Exercises = new List<Exercise>();
            }
            public void AddExercise(Exercise exercise)
            {
                Exercise e = new Exercise(exercise);
                Exercises.Add(e);
            }
            public void RemoveExercise(Exercise exercise)
            {
                Exercises.Remove(exercise);
            }
            public string GetName()
            {
                return this.Name;
            }
            public void SetName(string name)
            {
                this.Name = name;
            }
            public List<Exercise> GetExercises()
            {
                return this.Exercises;
            }
            public void SetExercises(List<Exercise> exercises)
            {
                this.Exercises = exercises;
            }
        }
    }

