using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3_PDWeek3_
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string word;
            Console.WriteLine("\t\t\t\t SHRITORI GAME");
            shritori g1 = new shritori();
            while (true)
            {
                Console.Write("Enter the word: ");
                word = Console.ReadLine();
                Console.WriteLine(string.Join(", ", (string[])g1.play(word)));
                if (g1.game_over)
                {
                    Console.Write("\n\n");
                    Console.Write(g1.restart());
                    Console.WriteLine("\n\n Press any key to restart.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
