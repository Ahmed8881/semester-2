using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task02pd
{
    internal class Enemy
    {
        public char enemychar;
        public int eX;
        public int eY;
       public Enemy(char echaracter, int ex, int ey)
        {
            this.enemychar = echaracter;
            this.eX = ex;
            this.eY = ey;
        }
    }
}
