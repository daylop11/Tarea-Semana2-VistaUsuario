using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    public partial class CUUsuarios : UserControl
    {
        public CUUsuarios()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FmrAgregar fmrAgregar = new FmrAgregar();
            fmrAgregar.Show();
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            FmrListar fmrListar = new FmrListar();
            fmrListar.Show();
        }
    }
}
//