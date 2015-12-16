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
       private List<string> produktai = new List<string>();
       private DuomenuBazesValdymas DB = new DuomenuBazesValdymas();

        public TiekejuRegistracija()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LaukuReiksmePaemimas();

            // Formos pildymas
            if (FormosTikrinimas())
            {
                LaukuReiksmiuNustatymas();
                RegistracijosVykdymas();
            }                
        }

        private void LaukuReiksmePaemimas()
        {
            this.ImonesPavadimas = textBox1.Text;
            this.ImonesKodas = textBox2.Text;
            this.PasirasimoData = dateTimePicker1.Text;
            this.SutartisPasibaigia = dateTimePicker2.Text;
        }

        private void LaukuReiksmiuNustatymas()
        {
            // Suteikiame reiksmes kurios bus iterpiamos i duomenu baze 
            DB.TiekejoKodas = Convert.ToInt32(this.ImonesKodas);
            DB.TiekejoPavadinimas = this.ImonesPavadimas;
            DB.SutartisPasirasyta = Convert.ToDateTime(this.PasirasimoData);
            DB.SutartiesPabaiga = Convert.ToDateTime(this.SutartisPasibaigia);
        }

        private void RegistracijosVykdymas()
        {
            // Registracijos vykdymas
            if (!DB.TiekejasEgzistuoja())
            {
                DB.TiekejuRegistracija();

                foreach (string produktas in produktai)
                {
                    DB.ProduktoPavadinimas = produktas;

                    if (!DB.ProduktasEgzistuoja())
                    {
                        DB.ProduktoRegistracija();
                    }
                }
                if (DB.TiekjuProduktuRegistracija())
                {
                    var Tregistracija2 = new TiekejuRegistracija2(this.ImonesPavadimas, this.ImonesKodas, this.PasirasimoData, this.SutartisPasibaigia, this.produktai);
                    MessageBox.Show("Registracija sekminga!");
                    this.Close();
                    Tregistracija2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Deja, ivyko klaida!");
                }
            }
            else
            {
                MessageBox.Show("Deja, tiekejas egzistuoja!");
            }
        }

        private Boolean FormosTikrinimas()
        {
            if (this.ImonesPavadimas == "")
            {
                MessageBox.Show("Palikote neužpildyta įmonės pavadinimo laukelį!");
                return false;
            }
            if (this.ImonesKodas == "")
            {
                MessageBox.Show("Palikote neužpildyta imones kodo laukelį!");
                return false;
            }
            if (this.PasirasimoData == "")
            {
                MessageBox.Show("Palikote neužpildyta imones kodo laukelį!");
                return false;
            }
            return true;
        }

            /*
                Pridetas prekiu pridejimas i sarasa.
                Daromas prekes patikrinimas ir jei tokios nera pridedamas i db
            */
        private void btnProduktai_Click(object sender, EventArgs e)
        {
            produktai.Add(tbProduktai.Text.ToString());
        }
    }
}
