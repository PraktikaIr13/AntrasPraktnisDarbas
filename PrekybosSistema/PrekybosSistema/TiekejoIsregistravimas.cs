﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrekybosSistema
{
    public partial class TiekejoIsregistravimas : Form
    {

        public TiekejoIsregistravimas()
        {
            InitializeComponent();
            label2.Hide();
            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();
            DB.TiekejuSarasas(this);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();
            DB.TiekejuSarasasIsregistravimui(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();
            DB.IsregistruotiTiekeja(this);

            listBox1.Items.Clear();
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

        }
    }
}
