using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Magic_dual_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            List<Stats>skillstatics =new List<Stats>();
            while (true)
            {
                Console.WriteLine(".............................Magic Dual............................");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Add Skill Statistics");
                Console.WriteLine("3. Display Player Info");
                Console.WriteLine("4. Learn a Skill");
                Console.WriteLine("5. Attack");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice= Console.ReadLine();
                if (choice == "1") { Console.Clear(); AddPlayer(players);  }
                else if (choice == "2") { Console.Clear(); AddSkillStatics(skillstatics); }
                else if (choice == "3") {
                    Console.Clear();
                    for (int i=0; i<players.Count; i++)
                        {
                        Console.WriteLine(players[i].viewplayer());
                        }
                    
                }
                else if (choice == "4") {
                    Console.Clear();
                    learn_a_skill(skillstatics,players);
                }
                else if (choice == "5") {
                    Console.Clear();
                    Attack(skillstatics,players);
                
                }
                else if (choice == "6") { Console.Clear();break; }
                else {
                    Console.WriteLine("Invalid choice ");
                }

            }
          
        }
        static void AddPlayer(List<Player>players) {
            Console.Write("Enter player name: ");
            string name = Console.ReadLine();

            Console.Write("Enter player health: ");
            float health = float.Parse(Console.ReadLine());

            Console.Write("Enter player max health: ");
            float maxHealth = float.Parse(Console.ReadLine());

            Console.Write("Enter player energy: ");
            float energy = float.Parse(Console.ReadLine());

            Console.Write("Enter player max energy: ");
            float maxEnergy = float.Parse(Console.ReadLine());

            Console.Write("Enter player armor: ");
            float armor = float.Parse(Console.ReadLine());

            Player player = new Player(name, health, energy, armor);
            players.Add(player);
            Console.WriteLine("Player added successfully.");
        }
        static void AddSkillStatics(List<Stats> skillStatics)
        {
            Console.Write("Enter skill name: ");
            string name = Console.ReadLine();

            Console.Write("Enter skill damage: ");
            float damage = float.Parse(Console.ReadLine());

            Console.Write("Enter skill armor penetration: ");
            float armorPenetration = float.Parse(Console.ReadLine());

            Console.Write("Enter skill heal amount: ");
            float healAmount = float.Parse(Console.ReadLine());

            Console.Write("Enter skill energy cost: ");
            float energyCost = float.Parse(Console.ReadLine());

            Console.Write("Enter skill description: ");
            string description = Console.ReadLine();

            Stats stats = new Stats(name, damage, armorPenetration, healAmount, energyCost, description);
            skillStatics.Add(stats);

            Console.WriteLine("Skill statistics added successfully.");
        }
       static void learn_a_skill(List<Stats> skillStatics, List<Player> players)
        {
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter skill name: ");
            string skillName = Console.ReadLine();

            Player player = players.Find(p => p.playerName == playerName);
            Stats stats = skillStatics.Find(s => s.SkillName == skillName);

            if (player != null && stats != null)
            {
                player.learnSkill(stats);
                Console.WriteLine($"{playerName} learned {skillName} skill.");
            }
            else
            {
                Console.WriteLine("Player or skill not found.");
            }
        }
        static void Attack(List<Stats> skillStatics, List<Player> players)
        {
            Console.Write("Choose attacking player: ");
            string attackerName = Console.ReadLine();

            Console.Write("Choose target player: ");
            string targetName = Console.ReadLine();

            Player attacker = players.Find(p => p.playerName == attackerName);
            Player target = players.Find(p => p.playerName == targetName);

            if (attacker != null && target != null)
            {
                string attackResult = attacker.attack(target);
                Console.WriteLine(attackResult);
            }
            else
            {
                Console.WriteLine("Attacker or target not found.");
            }
        }
    }
    }
