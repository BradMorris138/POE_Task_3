using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Task_3
{
    public class Map
    {
        List<Units> rangedunits = new List<Units>();
        List<Units> meleeunits = new List<Units>();
        List<Buildings> factorybuilding = new List<Buildings>();
        List<Buildings> resourcebuilding = new List<Buildings>();
        List<Units> units;
        List<Buildings> building;
        Random r = new Random();
        int unitNumbers;
        int fbuilding;
        int RBuilding;
        TextBox txtInfo;

        public List<Units> Units
        {
            get { return units; }
            set { units = value; }
        }

        public List<Buildings> Building
        {
            get { return building;}
            set { building = value; }
        }

       

        public Map(int n, TextBox txt)
        {
            units = new List<Units>();
            building = new List<Buildings>();
            unitNumbers = n;
            txtInfo = txt;
           
        }

        public void GenerateUnits()
        {
            for (int i = 0; i < unitNumbers; i++)
            {
                Melee r = new Melee(10, 10, 100, 50, 80, 200, 1, "@", true); //Assigning values to melee unit


                meleeunits.Add(r);
            }
            for (int j = 0; j < unitNumbers; j++)
            {
                Ranged_Unit ru = new Ranged_Unit(20, 20, 100, 200, 90, 150, 2, "^", true);//Creating a new renged unit. Adding values to ranged unit


                rangedunits.Add(ru);//Knows what to add to the list

            }

            for (int i = 0; i < unitNumbers; i++)
            {
                for(int j = 0; j < unitNumbers/2;j++)//Cuts units value in falf when attacked 
                {
                    if(r.Next(0,2) == 0)//The factory has been generate
                    {
                       Factory_Building fb = new Factory_Building(r.Next(0,25),r.Next(0, 25), 200, 3 , "$");

                       factorybuilding.Add(fb);

                    }
                }

                for(int l = 0; l < unitNumbers/2;l++)
                {
                    if(r.Next(0,2) == 0)
                    {
                        ResourceBuilding rb = new ResourceBuilding(r.Next(0, 25), r.Next(0, 25), 200, 4, "()","G",2, 300);
                        resourcebuilding.Add(rb);
                    }
                }


            }
        }

        public  void Buildings()
        {
            for (int i = 0; i < fbuilding; i++)
            {
                Factory_Building fb = new Factory_Building(20, 20, 100, 5, "F");
                factorybuilding.Add(fb);
            }

            for(int v = 0; v < RBuilding; v++)
            {
                ResourceBuilding rb = new ResourceBuilding(30, 30, 150, 1, "$", "G", 2, 50);
                resourcebuilding.Add(rb);
            }
        }



        public void Display(GroupBox gbxBox)
        {
            gbxBox.Controls.Clear();
            foreach(Units u in units)
            {
                Button b = new Button();
                if(u is Melee)
                {
                    Melee mu = (Melee)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.xPos * 20, mu.yPos * 20);
                    b.Text = mu.symbol;
                    if(mu.team ==0)
                    {
                        b.ForeColor = Color.Blue;
                    }
                    else
                    {
                        b.ForeColor = Color.Orange;
                    }
                }
                else
                {
                    Ranged_Unit ru = (Ranged_Unit)u;
                    b.Size = new Size(20,20)
                }
            }

            foreach (Ranged_Unit ru in rangedunits)
            {
                Label lblRange = new Label();
                lblRange.Width = 100;
                lblRange.Height = 100;
                lblRange.Location = new Point(ru.xPos * 100, ru.yPos * 100);
                lblRange.Text = ru.symbol;

                gbxBox.Controls.Add(lblRange);
            }

            foreach (Melee m in meleeunits)
            {
                Label lblMelee = new Label();
                lblMelee.Width = 200;
                lblMelee.Height = 200;
                lblMelee.Location = new Point(m.xPos * 100, m.yPos * 100);//How much the positions change
                lblMelee.Text = m.symbol;

                gbxBox.Controls.Add(lblMelee);
            }

            foreach (Factory_Building fb in factorybuilding)
            {
                Label lblFactory = new Label();
                lblFactory.Width = 250;
                lblFactory.Height = 250;
                lblFactory.Location = new Point(fb.XPos * 40, fb.YPos * 40);
                lblFactory.Text = fb.Symbol;
            }

        }
        public void Unit_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 100;
            y = b.Location.Y / 100;
            foreach (Units u in units)
            {
                if (u is Ranged_Unit)
                {
                    Ranged_Unit ru = (Ranged_Unit)u;
                    if (ru.xPos == x && ru.yPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is Melee)
                {
                    Melee mu = (Melee)u;
                    if (mu.xPos == x && mu.yPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }

            }
        }
    }
}
