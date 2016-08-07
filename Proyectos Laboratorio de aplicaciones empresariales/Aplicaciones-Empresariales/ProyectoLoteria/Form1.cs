using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLoteria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnKeyDown(KeyEventArgs keyEvent)
        {
            if (keyEvent.KeyCode == Keys.Enter)
            {
                pnlMenuPrincipal.Visible = true;
                pnlInicio.Visible = false;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            pnlJuego.Visible = true;
            pnlMenuPrincipal.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlSeleccionCartas.Visible = true;
            pnlMenuPrincipal.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlSeleccionCartas.Visible = false;
            pnlMenuPrincipal.Visible = true;
        }
        Carta c;
        private void button5_Click(object sender, EventArgs e)
        {
             c = new Carta("", "C:\\Users\\HéctorEdgar\\Desktop\\Escritorio\\Programas\\tema\\forest_lake_reflection_island_mist_97668_1920x1080.jpg",1,true);
            pnlJuego.Controls.Add(c.Picturebox);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            c.pintar();
        }
    }
}
