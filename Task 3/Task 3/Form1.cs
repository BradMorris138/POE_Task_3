﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        GameEngine engine;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblRound.Text = "Round: " + engine.Round.ToString();
            engine.Update();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, txtInfo, MapDisp);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            tbar1.Minimum = 0;
            tbar1.Maximum = 150;
            

        }
    }
    

      
}
