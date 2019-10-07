using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

namespace Task_3
{
    class Factory_Building:Buildings
    {
        public bool Destroyed { get; set; }
        private int Unit_Type;
        public int Prod_Speed
        {
            get { return prod_speed; }
        }


        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }

        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }

        public int MaxHealth
        {
            get { return base.maxhealth; }
        }

        public int Team
        {
            get { return base.team; }
        }

        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        

        public override void Destroy()
        {
            Destroyed = true;
            Symbol = "-";
        }

        public Factory_Building(int posiX, int posiY, int hp, int t, string symbols)
        {
            XPos = posiX;
            YPos = posiY;
            Health = hp;
            base.team = t;
            Symbol = symbols;
        }



        public Units UnitSpawns()
        {
            if (Team == 0)
            {
                if (Unit_Type == 0)
                {
                    Melee mu = new Melee(XPos, YPos, health, 100, 50, 20, 1, "%", true);//This will be the melee unit
                    return mu;
                }

                else
                {
                    Ranged_Unit ru = new Ranged_Unit(XPos, YPos, health, 100, 50, 10, 2, ")", true);
                    return ru;
                }
            }

            else
            {
                if (Unit_Type == 0)
                {
                    Melee mu = new Melee(XPos, YPos, health, 100, 50, 20, 1, "%", true);//This will be the melee unit
                    return mu;
                }

                else
                {
                    Ranged_Unit ru = new Ranged_Unit(XPos, YPos, health, 100, 50, 10, 2, "#", true);
                    return ru;
                }
            }
        }


        public override void Save(Buildings b, Units u)//Saving information to a DAT file
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("factorybuilding.dat", FileMode.Create, FileAccess.Write, FileShare.None);

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
        public Factory_Building()
        {

        }


        public override void Read()
        {
            Factory_Building b = new Factory_Building();
            BinaryFormatter bf = new BinaryFormatter();//Converting into compact folder which is easier to write to
            FileStream fs = new FileStream("factorybuilding.dat", FileMode.Open, FileAccess.Read, FileShare.None);//File stream is to write and read anything to a file whereas the read and write streams are used to write and read texts. File stream allows us to define a whole lot of values

            try
            {
                Factory_Building fb = (Factory_Building)bf.Deserialize(fs);



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        






        public override string ToString()
        {
            string temp = "";
            temp += "Position:";// temp is the name you are assingning to the variable
            temp += "{" + Health + "}";
            temp += "(" + XPos + "," + YPos + ")";
            temp += "{" + Symbol + ",";
            temp += "{" + Team + ",";


            return temp;
        }
    }
}
