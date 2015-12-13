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
        string imonesPavadimas;
        string imonesKodas;
        string pasirasimoData;
        string sutartisPasibaigia;

        public TiekejuRegistracija2(string imonesPavadimas, string imonesKodas, string pasirasimoData, string sutartisPasibaigia)
        {
            InitializeComponent();

            this.imonesPavadimas = imonesPavadimas;
            this.imonesKodas = imonesKodas;
            this.pasirasimoData = pasirasimoData;
            this.sutartisPasibaigia = sutartisPasibaigia;

            label2.Text = this.imonesPavadimas;
            label4.Text = this.imonesKodas;
            label6.Text = this.pasirasimoData;
            label8.Text = this.sutartisPasibaigia;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
