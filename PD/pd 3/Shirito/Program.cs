using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    internal class Program
    {
        public Shiritori s1 = new Shiritori();
        static void Main(string[] args)
        {
            Shiritori myShiritori = new Shiritori();

            while (true)
            {
                Console.WriteLine("Enter a word (or 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    break;
                }

                myShiritori.Play(input);
            }
        }
    }
  }


