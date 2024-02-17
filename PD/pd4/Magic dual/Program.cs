using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Dual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player alice = new Player("Alice", 110, 50, 10);
            Player Bob = new Player("bob", 100, 60, 20);
            Stats fireball = new Stats("Fireball",23, 5, 1, 15, "a fiery magical attack");
            alice.learnSkill(fireball);
            Console.WriteLine(alice.attack(Bob));

            Stats superbeam = new Stats("", 200, 50, 75, 50, "an overpowered attack, pls nerf");
            Console.WriteLine(Bob.attack(alice));
        }
    }
}
