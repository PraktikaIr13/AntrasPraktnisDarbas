using System;
using System.Windows.Forms;

namespace PrekybosSistema
{
    public partial class TiekejuRegistracija : Form
    {
        string imonesPavadimas;
        string imonesKodas;
        string pasirasimoData;
        string sutartisPasibaigia;

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
            DB.tiekejoKodas = Convert.ToInt32(this.imonesKodas);
            DB.tiekejoPavadinimas = this.imonesPavadimas;
            DB.sutartisPasirasyta = Convert.ToDateTime(this.pasirasimoData);
            DB.sutartiesPabaiga = Convert.ToDateTime(this.sutartisPasibaigia);


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
                if(DB.tiekejuRegistracija().Equals(true))
                    MessageBox.Show("Naujas tiekėjas užregistruotas!");
                else
                    MessageBox.Show("Deja, kilo techninių problemų!");

                
                // Visi duomenys užpildyti teisingai
                var Tregistracija2 = new TiekejuRegistracija2(this.imonesPavadimas, this.imonesKodas, this.pasirasimoData, this.sutartisPasibaigia);
                Tregistracija2.ShowDialog();

                this.Close();
            }
        }
    }
}
