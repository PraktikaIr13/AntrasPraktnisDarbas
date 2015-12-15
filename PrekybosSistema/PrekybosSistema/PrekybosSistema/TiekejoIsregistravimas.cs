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
    public partial class TiekejoIsregistravimas : Form
    {

        public TiekejoIsregistravimas()
        {
            InitializeComponent();
            label2.Hide();
            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();
            DB.tiekejuSarasas(this);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DuomenuBazesValdymas DB = new DuomenuBazesValdymas();
            DB.tiekejuSarasasIsregistravimui(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
