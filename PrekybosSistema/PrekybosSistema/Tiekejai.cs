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
    public partial class Tiekejai : Form
    {

        public Tiekejai()
        {
            InitializeComponent();

            DuomenuBazesValdymas cn = new DuomenuBazesValdymas();
        }
    }
}
