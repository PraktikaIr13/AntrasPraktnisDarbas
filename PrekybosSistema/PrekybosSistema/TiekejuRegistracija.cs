﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PrekybosSistema
{
    public partial class    TiekejuRegistracija : Form
    {
        string imonesPavadimas;
        string imonesKodas;
        string pasirasimoData;
        string sutartisPasibaigia;
        List<string> produktai = new List<string>();

        public TiekejuRegistracija()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.imonesPavadimas = textBox1.Text;
            this.imonesKodas = textBox2.Text;
            this.pasirasimoData = dateTimePicker1.Text;
            this.sutartisPasibaigia = dateTimePicker2.Text;

            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();

            // Suteikiame reiksmes kurios bus iterpiamos i duomenu baze
            DB.TiekejoKodas = Convert.ToInt32(this.imonesKodas);
            DB.TiekejoPavadinimas = this.imonesPavadimas;
            DB.SutartisPasirasyta = Convert.ToDateTime(this.pasirasimoData);
            DB.SutartiesPabaiga = Convert.ToDateTime(this.sutartisPasibaigia);


            if (this.imonesPavadimas == "")
            {
                MessageBox.Show("Palikote neužpildyta įmonės pavadinimo laukelį!");
            }else if (this.imonesKodas == "")
            {
                MessageBox.Show("Palikote neužpildyta imones kodo laukelį!");
            }
            else if (this.pasirasimoData == "")
            {
                MessageBox.Show("Palikote neužpildyta imones kodo laukelį!");
            }
            else
            {
                if(DB.TiekejuRegistracija().Equals(true))
                    MessageBox.Show("Naujas tiekėjas užregistruotas!");
                else
                    MessageBox.Show("Deja, kilo techninių problemų!");

                
                // Visi duomenys užpildyti teisingai
                var Tregistracija2 = new TiekejuRegistracija2(this.imonesPavadimas, this.imonesKodas, this.pasirasimoData, this.sutartisPasibaigia);
                Tregistracija2.ShowDialog();

                this.Close();
            }
        }

        /*
   Pridetas prekiu pridejimas i sarasa.
   Daromas prekes patikrinimas ir jei tokios nera pridedamas i db
*/
        private void btnProduktai_Click(object sender, EventArgs e)
        {
            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();

            DB.ProduktoPavadinimas = tbProduktai.Text.ToString();

            if (DB.ProduktuRegistracija().Equals(true))
            {
                MessageBox.Show("Naujas produktas uzregistruotas!");
                //produktai.Add(tbProduktai.Text.ToString());
                tbProduktai.Text = "";
                return;
            }
            if (DB.ProduktuRegistracija().Equals(false))
            {
                MessageBox.Show("Deja, toks produktas jau yra!");
                tbProduktai.Text = "";
            }

        }
    }
}
