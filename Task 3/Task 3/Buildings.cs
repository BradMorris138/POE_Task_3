using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    [Serializable]
    public abstract class Buildings
    {
        public string Armory, Medic_Center, Bullet_Factory, Engine_Factory, Medical_Vehicle, Tank_Factory, Chemical_Factory;
        protected int xPos, yPos;
        protected int health;
        protected int maxhealth;
        protected int team;
        protected string symbol;
        protected int prod_speed;




        public abstract void Destroy();

        public abstract override string ToString();
        

        public abstract void Save(Buildings b, Units u);

        public abstract void Read();
        
    }
}
