using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Dual
{
    internal class Player
    {
        public float health;
        public float Maxhealth;
        public float Energy;
        public float MaxEnergy;
        public float armour;
        public string playerName;
        public Stats skillStatics;

        public Player(string name,float health,float Energy, float armour)
        {
            this.playerName = name;
            this.health = health;
            this.Energy=Energy;
            this.armour = armour;

        }
        public void Update_energy(float value)
        {
             Energy += value;
            if (    Energy < 0)
            {
                Energy = 0;
            }
            else if (Energy > MaxEnergy)
            {
                Energy = MaxEnergy;
            }
        }
        public void Update_health(float value)
        {
            health += value;
            if (health < 0)
            {
                health = 0;
            }
            else if (health > Maxhealth)
            {
                health = Maxhealth;
            }
        }
        public void Update_armour(float value)
        {
            armour += value;
        }
        public void UpdateName(string newName)
        {
            playerName = newName;
        }



        public void learnSkill(Stats skill)
        {
            skillStatics = skill;
            Console.WriteLine($"{playerName} succesfully learned {skill.SkillName}");
        }
        public string attack(Player target)
        {
            if (skillStatics == null)
            {
                Console.WriteLine();
                return $"{playerName} does not have any skill statistics!";
            }
            float effective_Armour = target.armour - skillStatics.penetration;
            if(effective_Armour < 0) { effective_Armour = 0; }
            if(skillStatics.cost>Energy)
            {
                return ($"{playerName} attempted to use {skillStatics.SkillName} but didnot have enough energy!");
            }
            //if cost is less than Energy then this will execute...
                Energy -= skillStatics.cost;
            float damage = 0;
            damage=skillStatics.damage*(100-effective_Armour/100);
            string returningline = ($"{playerName} used {skillStatics.SkillName}, {skillStatics.description} against {target.playerName} doing {damage} damage!! ");
            if (skillStatics.heal > 0)
            {
                Update_health(skillStatics.heal);
                returningline += $"\n {playerName} healed for {skillStatics.heal} health.";
            }
           else if (target.health <= 0)
            {
                returningline += $"\n {target.playerName} died.";
            }
            else
            {
                float target_hp=(target.health/target.Maxhealth)*100;
                returningline += ($"\n {target.playerName} is at {target_hp}");
            }

            return returningline;
        }
    }
   
}
