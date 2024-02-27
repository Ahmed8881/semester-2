using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WorkOutRoutine workoutRoutine = new WorkOutRoutine("Leg Day");
            Exercise BenchPress = new Exercise("Push Up");
            Exercise InclineBenchPress = new Exercise("Chin Up");
            Exercise DeclineBenchPress = new Exercise("PushUp");
            Sets BenchPressSet1 = new Sets(135, 12);
            Sets BenchPressSet2 = new Sets(185, 10);
            Sets BenchPressSet3 = new Sets(225, 8);
            BenchPress.AddSet(BenchPressSet1);
            BenchPress.AddSet(BenchPressSet2);
            BenchPress.AddSet(BenchPressSet3);
            workoutRoutine.AddExercise(BenchPress);
            workoutRoutine.AddExercise(InclineBenchPress);
            workoutRoutine.AddExercise(DeclineBenchPress);
            Console.WriteLine("Workout Routine: " + workoutRoutine.GetName());
            foreach (Exercise exercise in workoutRoutine.GetExercises())
            {
                Console.WriteLine("Exercise: " + exercise.GetName());
                foreach (Sets set in exercise.GetSets())
                {
                    Console.WriteLine("Weight: " + set.GetWeight() + " Reps: " + set.GetReps());
                }
            }
        }
    }
}
