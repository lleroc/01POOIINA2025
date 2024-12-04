using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Mi_Primera_Vez.Presentacion.Personal
{
    public partial class Frmpersonal : Form
    {
        public bool modoEdision = false;
        public Frmpersonal(string modo)
        {
            InitializeComponent();
            if (modo != "n") this.modoEdision = true;            
        }

        private void Frmpersonal_Load(object sender, EventArgs e)
        {
            if (!this.modoEdision)
            {
                lblFrmPersonal.Text = "Ingreso de Nuevo Personal";
            }
            else { 
                lblFrmPersonal.Text = "Actualziacion de Personal";
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(char.IsControl(e.KeyChar).ToString());
            //MessageBox.Show(char.IsDigit(e.KeyChar).ToString());
            // "."   "-"
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }
    }
}
