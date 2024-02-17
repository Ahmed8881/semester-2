using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Dual
{
    internal class Stats
    {
        public string SkillName;
        public float damage;
        public string description;
        public float penetration;
        public float cost;
        public float heal;
        public Stats(string SkillName,float damage,float penetration,float heal,float cost, string description) { 
            this.SkillName = SkillName;
            this.damage = damage;
            this.description = description;
            this.penetration = penetration;
            this.cost = cost;
            this.heal = heal;

        }

    }
}
