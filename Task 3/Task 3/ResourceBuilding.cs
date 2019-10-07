using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;//Allow to write to serialized file
using System.IO;


namespace Task_3
{
    class ResourceBuilding: Buildings
    {


       
        public bool Destroyed { get; set; }
        Random r = new Random();


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

        public int Team
        {
            get { return base.team; }

        }

        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        string Resource_Type;
        int Resource_Generated;
        int Resources_Per_Round;
        int Resource_Pool_Remaining;

        public ResourceBuilding(int posiX, int posiY, int hp, int teamss, string symbols, string resource, int resource_perround, int resource_pool)
        {
            XPos = posiX;
            YPos = posiY;
            Health = hp;
            team = teamss;
            Symbol = symbols;
            Resource_Type = resource;
            Resource_Generated = resource_perround;

        }

        public override string ToString()
        {
            string temp = "";
            temp += "(" + XPos + "," + YPos + ")";
            temp += "{ Total resources: " + Resource_Pool_Remaining.ToString();
            temp += "{ Resources for each round" + Resources_Per_Round;
            temp += "(" + Health + ")";
            temp += "(" + Symbol + ")";
            temp += (Destroyed ? " Working" : "Not Working");

            return temp;
        }





        public void GenerateResources(int rounds, Label lbl, Label l2 ,Timer time1)
        {
            do
            {
                for (int i = 0; i < Resource_Pool_Remaining; i++)
                {
                    Resource_Type.Remove(i);//This indicates that the building has been destroyed as a result of resource depletion
                    if (i > Resource_Pool_Remaining)
                    {
                        Destroyed = true;
                    }


                    lbl.Text = "Resource type is:" + Resource_Type;
                    lbl.Text = "Resources have been received:" + i.ToString();
                }

            }
            while (rounds < Resource_Pool_Remaining);


        }

        
        public override void Destroy()
        {
            symbol = "-";
            Destroyed = true;
        }

       





        public override void Save(Buildings b, Units u)//Saving information to a DAT file
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("resourcebuilding.dat", FileMode.Create, FileAccess.Write, FileShare.None);

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


        public override void Read()
        {

        }
    }
}

