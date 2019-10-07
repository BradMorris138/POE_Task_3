using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task_3
{
    class GameEngine
    {
        Map map;
        Random r = new Random();
        GroupBox MapDisp;
        

        private int round;
        public int Round
        {
            get { return round; }
        }

        public GameEngine(int amountUnits,  TextBox txtInfo, GroupBox grpMap)
        {
            MapDisp = grpMap;
            map = new Map(amountUnits, txtInfo);
            map.GenerateUnits();
            map.Display(MapDisp);
            round = 1;
        }

        
        public void Update()
        {
            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is Melee)
                {
                    Melee mu = (Melee)map.Units[i];
                    if (mu.health <= mu.maxhealth * 50/100 *100) 
                    {
                        mu.Move((Directions)r.Next(0,4));
                    }
                    else
                    {
                        (Units closest, int dist) = mu.Closest(map.Units);//This is to check if the unit is in range

                        
                        if (dist <= mu.ackrange)
                        {
                            mu.Attacking = true;
                            mu.Conflict(closest);
                        }
                        else 
                        {
                            if (closest is Melee)
                            {
                                Melee closestMu = (Melee)closest;
                                if (mu.xPos > closestMu.xPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.xPos < closestMu.xPos) //South
                                {
                                    mu.Move((Directions)2);
                                }
                                else if (mu.yPos > closestMu.yPos) //West
                                {
                                    mu.Move((Directions)3);
                                }
                                else if (mu.yPos < closestMu.yPos) //East
                                {
                                    mu.Move((Directions)1);
                                }
                            }
                            else if (closest is Ranged_Unit)
                            {
                                Ranged_Unit closestru = (Ranged_Unit)closest;
                               
                                    if (mu.xPos > closestru.xPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.xPos < closestru.xPos) //South
                                {
                                    mu.Move((Directions)2);
                                }
                                else if (mu.yPos > closestru.yPos) //West
                                {
                                    mu.Move((Directions)3);
                                }
                                else if (mu.yPos < closestru.yPos) //East
                                {
                                    mu.Move((Directions)1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is Ranged_Unit)
                {
                    Ranged_Unit ru = (Ranged_Unit)map.Units[i];
                    if (ru.health <= ru.health * 50/100 *100) //The ranged unit runs away when health is below 50
                    {
                        ru.Move((Directions)r.Next(0, 4));
                    }
                    (Units closest, int dist) = ru.Closest(map.Units);

                    
                    if (dist <= ru.ackrange)//This checks if the units are in range of eachother
                    {
                        ru.Attacking = true;
                        ru.Conflict(closest);
                    }
                    else 
                    {
                        if (closest is Melee)
                        {
                            Melee closestMu = (Melee)closest;
                            if (ru.xPos > closestMu.xPos) //North
                            {
                                ru.Move(0);
                            }
                            else if (ru.xPos < closestMu.xPos) //South
                            {
                                ru.Move((Directions)2);
                            }
                            else if (ru.yPos > closestMu.yPos) //West
                            {
                                ru.Move((Directions)3);
                            }
                            else if (ru.yPos < closestMu.yPos) //East
                            {
                                ru.Move((Directions)1);
                            }
                        }
                        else if (closest is Ranged_Unit)
                        {
                            Ranged_Unit closestRu = (Ranged_Unit)closest;
                            if (ru.xPos > closestRu.xPos) //North
                            {
                                ru.Move(0);
                            }
                            else if (ru.xPos < closestRu.xPos) //South 
                            {
                                ru.Move((Directions)2);
                            }
                            else if (ru.yPos > closestRu.yPos) //West
                            {
                                ru.Move((Directions)3);
                            }
                            else if (ru.yPos < closestRu.yPos) //East
                            {
                                ru.Move((Directions)1);
                            }
                        }
                    }

                  

                }

              
            }
            map.Display(MapDisp);
            round++;

              
        }

        

       



    }
}

