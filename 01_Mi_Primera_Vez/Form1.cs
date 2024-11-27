using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            string nombres = txt_Nombre.Text;
            string apellidos = txt_Apellido.Text;

            lst_Estudiantes.Items.Add(nombres + " " + apellidos);
            MessageBox.Show("Se guardo con exito");
        }

        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }
    }
}
