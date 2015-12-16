using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PrekybosSistema
{
    public partial class    TiekejuRegistracija : Form
    {
       public string ImonesPavadimas { get; set; }
       public string ImonesKodas { get; set; }
       public string PasirasimoData { get; set; }
       public string SutartisPasibaigia { get; set; }
        List<string> produktai = new List<string>();

        public TiekejuRegistracija()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.ImonesPavadimas = textBox1.Text;
            this.ImonesKodas = textBox2.Text;
            this.PasirasimoData = dateTimePicker1.Text;
            this.SutartisPasibaigia = dateTimePicker2.Text;

            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();

            // Suteikiame reiksmes kurios bus iterpiamos i duomenu baze 
            DB.TiekejoKodas = Convert.ToInt32(this.ImonesKodas);
            DB.TiekejoPavadinimas = this.ImonesPavadimas;
            DB.SutartisPasirasyta = Convert.ToDateTime(this.PasirasimoData);
            DB.SutartiesPabaiga = Convert.ToDateTime(this.SutartisPasibaigia);

            // Formos pildymas
            if (this.ImonesPavadimas == "")
            {
                MessageBox.Show("Palikote neužpildyta įmonės pavadinimo laukelį!");
            }
            if (this.ImonesKodas == "")
            {
                MessageBox.Show("Palikote neužpildyta imones kodo laukelį!");
            }
            if (this.PasirasimoData == "")
            {
                MessageBox.Show("Palikote neužpildyta imones kodo laukelį!");
            }
            // Registracijos vygdimas
            if (DB.TiekejuRegistracija())
            {
                MessageBox.Show("Naujas tiekėjas užregistruotas!");

                if (DB.TiekjuProduktuRegistracija())
                {
                    MessageBox.Show("tarkim taip!");
                }

                // Visi duomenys užpildyti teisingai
                var Tregistracija2 = new TiekejuRegistracija2(this.ImonesPavadimas, this.ImonesKodas, this.PasirasimoData, this.SutartisPasibaigia, this.produktai);
                this.Close();
                Tregistracija2.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("Deja, toks tiekejo imones kodas jau yra!");
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

            if (DB.ProduktuRegistracija())
            {
                MessageBox.Show("Naujas produktas uzregistruotas!");
                produktai.Add(tbProduktai.Text.ToString());
                tbProduktai.Text = "";
                return;
            }
            else
            {
                MessageBox.Show("Deja, toks produktas jau yra!");
                produktai.Add(tbProduktai.Text.ToString());
                tbProduktai.Text = "";
            }

        }
    }
}
