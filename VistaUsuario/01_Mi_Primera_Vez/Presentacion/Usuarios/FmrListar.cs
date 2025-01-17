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
    public partial class FmrListar : Form
    {
        public FmrListar()
        {
            InitializeComponent();
        }
        public void cargaGrilla()
        {
            var logicaUsuario = new cls_usuario();
            var autoincrmento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            gridUsuarios.Columns.Add(autoincrmento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };


            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            gridUsuarios.DataSource = logicaUsuario.todos();

            gridUsuarios.Columns["Nombre"].HeaderText = "Nombre";
            gridUsuarios.Columns["Edad"].HeaderText = "Edad";

            

            gridUsuarios.Columns.Add(btnEditar);
            gridUsuarios.Columns.Add(btnEliminar);

            //dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void FmrListar_Load(object sender, EventArgs e)
        {
            this.cargaGrilla();
        }
    }
}
