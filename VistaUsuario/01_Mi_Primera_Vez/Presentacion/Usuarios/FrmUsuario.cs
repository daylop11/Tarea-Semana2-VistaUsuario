using System;


private void button2_Click(object sender, EventArgs e)
{
    var dto_Usuario = new Datos.dto_Usuario
    {
        edad = txtedad.Text,
        nombre = txtNombres .Text,
        fechaNacimento = txtFechaNacimento.Text
    };

    var cls_usuario = new cls_usuario();

    if (cls_usuario.Insertar(dto_Usuario) == "ok")
    {
        MessageBox.Show("Se guardo con exito");
        this.Close();
    }
    else
    {
        MessageBox.Show("Error al guardar");
    }


}