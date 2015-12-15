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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tiekejuRegistracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Tregistracija = new TiekejuRegistracija();
            Tregistracija.ShowDialog();
        }

        private void tiekėjųIšregistravimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Tisregistracija = new TiekejoIsregistravimas();
            Tisregistracija.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void produktųRedagavimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var produktuPerziura = new ProduktuPerziura();
            produktuPerziura.ShowDialog();
        }
    }
}
