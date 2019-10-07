using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task_3
{
    
    
        class Melee : Units
        {

        public bool Destroyed { get; set; }
            public override/*Overrides Conflict in unit class*/ void Conflict(Units Attack)//Calculating Attack Damage. Accessing actual damage in unit class.
            {

            }

            public override/*Overrides AckRange in unit class*/ bool ConflictRange(Units other)//Calculating the range the weapon can go 
            {
            int distance = 0;
            int otherX = 0;
            int otherY = 0;
            if (other is Melee)
            {
                otherX = ((Melee)other).xPos;
                otherY = ((Melee)other).yPos;
            }
            else if (other is Ranged_Unit)
            {
                otherX = ((Ranged_Unit)other).xPos;
                otherY = ((Ranged_Unit)other).yPos;
            }


            if (distance <= ackrange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

            public override/*Overrides Reset in unit class*/ (Units,int)Closest(List<Units> units)//Calculating where the players will return to Accessing actual damage in  unit class
            {
            int nearest = 50;
            Units closest = this;
            //Closest Unit and Distance                    
            foreach (Units u in units)
            {
                if (u is Melee)
                {
                    Melee otherMu = (Melee)u;
                    int distance = Math.Abs(this.XPos - otherMu.xPos)
                               + Math.Abs(this.YPos - otherMu.yPos);
                    if (distance < nearest)
                    {
                        nearest = distance;
                        closest = otherMu;
                    }
                }
                else if (u is Ranged_Unit)
                {
                    Ranged_Unit otherRu = (Ranged_Unit)u;
                    int distance = Math.Abs(this.XPos - otherRu.xPos)
                               + Math.Abs(this.YPos - otherRu.yPos);
                    if (distance < nearest)
                    {
                        nearest = distance;
                        closest = otherRu;
                    }
                }



            }
            return (closest, nearest);
            }

            public override/*Overrides  Destroy in unit class*/ void Destroy()//Calculating damage 
            {
            symbol = " - ";
            Destroyed = true;
            }

            public override void Save(Buildings b)//Saving information to a DAT file
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream("melee.dat", FileMode.Create, FileAccess.Write, FileShare.None);

                try
                {
                    bf.Serialize(fs, b);
                    fs.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }



            }

       

            public Melee(int posx, int posy, int health, int rspeed, int attack, int ackrange, int team, string symbol, bool atck)//Declaring constructor
            {
                XPos = posx;
                YPos = posy;
                Health = health;
                base.MaxHealth = health;
                RSpeed = rspeed;
                Attack = attack;
                AckRange = 1;
                base.Team = team;
                Symbol = symbol;
                atck = true;
            }
            Random r = new Random();




            public int xPos
            {
                get { return base.XPos; }
                set { XPos = value; }
            }



            public int yPos
            {
                get { return base.YPos; }
                set { YPos = value; }
            }





            public int health
            {
                get { return base.Health; }
                set { Health = value; }
            }



            public int maxhealth//Max Health
            {
                get { return base.MaxHealth; }
            }



            public int rspeed
            {
                get { return base.RSpeed; }
                set { RSpeed = value; }
            }



            public int attack
            {
                get { return base.Attack; }
                set { Attack = value; }
            }



            public int ackrange
            {
                get { return base.AckRange; }
                set { AckRange = value; }
            }



            public int team
            {
                get { return base.Team; }
            }

            public string symbol
            {
                get { return base.Symbol; }
                set { Symbol = value; }
            }

            public bool Attacking
            {
                get { return base.attacking; }
                set { attacking = value; }
            }



            public override void Move(Directions d)//Actual coding of movement
            {
                int directions = r.Next(0, 4);
                switch (d)
                {
                    case Directions.North:
                        YPos--;
                        break;
                    case Directions.East:
                        XPos++;
                        break;
                    case Directions.South:
                        YPos++;
                        break;
                    case Directions.West:
                        XPos--;
                        break;
                    default: break;
                }
            }
            public override string ToString()
            {
                return "Melee: " + " ( " + XPos + " ," + YPos + " )"
                    + " ," + Health + " ," + Attack + " ," + AckRange + " ," + RSpeed;
            }

        }
}

