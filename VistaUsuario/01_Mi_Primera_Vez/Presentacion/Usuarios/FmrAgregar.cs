using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_Mi_Primera_Vez.Datos;
using _01_Mi_Primera_Vez.Logica;
namespace _01_Mi_Primera_Vez.Presentacion.Usuarios
{
    public partial class FmrAgregar : Form
    {
        cls_usuario logicaUsuario = new cls_usuario();
        

        public FmrAgregar()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            dto_usuario dto_Usuario = new dto_usuario
            {
                nombre = txtNombreApellido.Text,
                edad = Convert.ToInt32(txtEdad.Text)
                
            };
            var resultado = logicaUsuario.Insertar(dto_Usuario);


            if (resultado == "ok")
            {
                MessageBox.Show("Usuario insertado exitosamente");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error - " + resultado);

            }

        }
    }
}
