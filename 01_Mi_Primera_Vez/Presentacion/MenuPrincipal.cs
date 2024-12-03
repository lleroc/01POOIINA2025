using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _01_Mi_Primera_Vez.Presentacion.POO;
namespace _01_Mi_Primera_Vez.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            /*
             
            black
            greeb
            white
            
            
                  0-255  0-255  0-255
            rgb (red  , green, blue)




                  25    200    0      0 - 1
            rgba(red, green, blue, transparencia)

             
             
             
             
             
             
             */




        }

        private void button2_Click(object sender, EventArgs e)
        {
            CUPersonal frmPrueba = new CUPersonal();
            PanelGeneral.Controls.Clear();
            frmPrueba.Dock = DockStyle.Fill;
            PanelGeneral.Controls.Add(frmPrueba);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMostrar pruebas = new frmMostrar();
            pruebas.Show();
        }
    }
}
