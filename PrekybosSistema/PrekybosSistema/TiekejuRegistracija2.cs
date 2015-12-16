using System;
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
    public partial class TiekejuRegistracija2 : Form
    {

       public string ImonesPavadimas { get; set; }
       public string ImonesKodas { get; set; }
       public string PasirasimoData { get; set; }
       public string SutartisPasibaigia { get; set; }
       private List<string> produktai = new List<string>();

        public TiekejuRegistracija2(string imonesPavadimas, string imonesKodas, string pasirasimoData, string sutartisPasibaigia, List<string> produktai)
        {
            InitializeComponent();

            this.ImonesPavadimas = imonesPavadimas;
            this.ImonesKodas = imonesKodas;
            this.PasirasimoData = pasirasimoData;
            this.SutartisPasibaigia = sutartisPasibaigia;
            this.produktai = produktai;

            label2.Text = this.ImonesPavadimas;
            label4.Text = this.ImonesKodas;
            label6.Text = this.PasirasimoData;
            label8.Text = this.SutartisPasibaigia;
            listBox1.DataSource = produktai;
        
        }

        /*
            Pridetas isejimas is lango
        */
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
