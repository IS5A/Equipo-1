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
        private Controlador control;
        private int variable1;
        private int variable2;
        private Graphics gp;
        
        public Form1()
        {
            InitializeComponent();
            this.variable1 = Convert.ToInt16(nuNumTabla1.Value);
            this.variable2 = Convert.ToInt16(nuNumTabla2.Value);
            this.control = new Controlador();
            this.control.crearCartas();
            
        }
        protected override void OnKeyDown(KeyEventArgs keyEvent)
        {
            
            if (keyEvent.KeyCode == Keys.Enter)
            {
                generarTablasAleatorias();
                pnlMenuPrincipal.Visible = true;
                pnlInicio.Visible = false;
            }
            

        }
        private int verificarNumerosAdelante(int i, int j)
        {
            
                if (i==j)
                {
                    i++;
                    if (i > 6)
                    {
                        i = 1;
                    }
                }
                
           
            return i;
        }
        private int verificarNumerosAtras(int i, int j)
        {

            if (i == j)
            {
                i--;
                if (i < 1)
                {
                    i = 6;
                }
            }


            return i;
        }
        private void generarTablasAleatorias()
        {
            this.control.crearTablasPredeterminadas(6, 54, new Point(pnlTablaPredeterminada1.Size.Width, pnlTablaPredeterminada1.Size.Height + 1));
            int cont = 0;
            List<Tabla> tablasPredeterminadas = this.control.TablasPredeterminadas;
            foreach (Tabla tabla in tablasPredeterminadas)
            {
                List<Carta> cartas = tabla.Cartas;
                switch (cont++)
                {
                    case 0:
                        pnlTablaPredeterminada1.Controls.Clear();
                        foreach (Carta item in cartas)
                        {
                            
                            pnlTablaPredeterminada1.Controls.Add(item.Picturebox);
                        }
                        break;

                    case 1:
                        pnlTablaPredeterminada2.Controls.Clear();
                        foreach (Carta item in cartas)
                        {
                            pnlTablaPredeterminada2.Controls.Add(item.Picturebox);
                        }
                        break;
                    case 2:
                        pnlTablaPredeterminada3.Controls.Clear();
                        foreach (Carta item in cartas)
                        {
                            pnlTablaPredeterminada3.Controls.Add(item.Picturebox);
                        }
                        break;
                    case 3:
                        pnlTablaPredeterminada4.Controls.Clear();
                        foreach (Carta item in cartas)
                        {
                            pnlTablaPredeterminada4.Controls.Add(item.Picturebox);
                        }
                        break;
                    case 4:
                        pnlTablaPredeterminada5.Controls.Clear();
                        foreach (Carta item in cartas)
                        {
                            pnlTablaPredeterminada5.Controls.Add(item.Picturebox);
                        }
                        break;
                    case 5:
                        pnlTablaPredeterminada6.Controls.Clear();
                        foreach (Carta item in cartas)
                        {
                            pnlTablaPredeterminada6.Controls.Add(item.Picturebox);
                        }
                        break;


                }

            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            btnVolverjugar.Visible = false;
            btnRegresarSeleccion.Visible = true;
            control.SeleccionarTablaJugador1(Convert.ToInt16(nuNumTabla1.Value));
            this.control.CrearTablaPrincipal9X6(pnlTablaPrincipal.Size);
            if (rbJugador1.Checked)
            {
                 this.control.Jugador1=true;
            }else
            {
                control.SeleccionarTablaJugador2(Convert.ToInt16(nuNumTabla2.Value));
                this.control.Jugador1 = false;
            }
            pnlMenuPrincipal.Visible = false;
            pintarTablerosJuego();
            pnlJuego.Visible = true;
            
        }


        private void PintarTablaPrincipal()
        {
            //pnlTablaPrincipal.Controls.Clear();
            List<Carta> cartas = this.control.TablaPrincipal.Cartas;

            foreach (Carta item in cartas)
            {
                pnlTablaPrincipal.Controls.Add(item.Picturebox);
            }
        }

        private void pintarTabla1Jugador()
        {
            //pnlJugador1.Controls.Clear();
            List<Carta> cartas= this.control.TablaJugador1.Cartas;

            foreach (Carta item in cartas)
            {
                pnlJugador1.Controls.Add(item.Picturebox);
            }
            pintarCartaPrincipal();
            PintarTablaPrincipal();
        }


        private void pintarCartaPrincipal()
        {
            pnlJuegoCarta.Controls.Clear();
            pnlJuegoCarta.Controls.Add(this.control.CartaPrincipal.Picturebox);
        }
        private void pintarTabla2Jugadores()
        {
            //pnlJugador1.Controls.Clear();
            //pnlJugador2.Controls.Clear();
            List<Carta> cartas = this.control.TablaJugador1.Cartas;

            foreach (Carta item in cartas)
            {
                pnlJugador1.Controls.Add(item.Picturebox);
            }

            List<Carta> cartas2 = this.control.TablaJugador2.Cartas;

            foreach (Carta item in cartas2)
            {
                pnlJugador2.Controls.Add(item.Picturebox);
            }
            pintarCartaPrincipal();
            PintarTablaPrincipal();

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
        
        private void button5_Click(object sender, EventArgs e)
        {
            this.control.IniciarJuego();
            btnIniciarJuego.Visible = false;
            this.control.CartaSiguiente();
            btnCartaSiguiente.Visible = true;
            pintarTablerosJuego();


        }

   

        

        private void rbJugador2_CheckedChanged(object sender, EventArgs e)
        {
            nuNumTabla2.Value = verificarNumerosAdelante(Convert.ToInt16(nuNumTabla2.Value), Convert.ToInt16(nuNumTabla1.Value));
            if (rbJugador2.Checked) {
                nuNumTabla2.Enabled = true;
            } else
            {
                nuNumTabla2.Enabled = false;
            }
        }
        
        private void nuNumTabla1_ValueChanged(object sender, EventArgs e)
        {
            if (rbJugador2.Checked)
            {
                if (variable1 < nuNumTabla1.Value)
                {
                    nuNumTabla1.Value = verificarNumerosAdelante(Convert.ToInt16(nuNumTabla1.Value), Convert.ToInt16(nuNumTabla2.Value));

                } else
                {
                    nuNumTabla1.Value = verificarNumerosAtras(Convert.ToInt16(nuNumTabla1.Value), Convert.ToInt16(nuNumTabla2.Value));

                }
                variable1 = Convert.ToInt16(nuNumTabla1.Value);
            }
        }

        private void nuNumTabla2_ValueChanged(object sender, EventArgs e)
        {
            if (variable2 < nuNumTabla2.Value)
            {
                nuNumTabla2.Value = verificarNumerosAdelante(Convert.ToInt16(nuNumTabla2.Value), Convert.ToInt16(nuNumTabla1.Value));

            }
            else
            {
                nuNumTabla2.Value = verificarNumerosAtras(Convert.ToInt16(nuNumTabla2.Value), Convert.ToInt16(nuNumTabla1.Value));

            }
            variable2 = Convert.ToInt16(nuNumTabla2.Value);
        }
        private void pintarTablerosJuego()
        {
            if (this.control.Jugador1)
            {
                pintarTabla1Jugador();
            }else
            {
                pintarTabla2Jugadores();
            }
        }
        private void verificarGanador()
        {
            if (this.control.GanoJugador1)
            {
                MessageBox.Show("Loteria del Jugador 1");
                btnCartaSiguiente.Visible = false;
                btnVolverjugar.Visible = true;
                btnRegresarSeleccion.Visible = true;
                lblGanador.Text = "Gano el Jugador 1";
                lblGanador.Visible = true;
            }
            if (this.control.GanoJugador2)
            {
                MessageBox.Show("Loteria del Jugador 2");
                btnCartaSiguiente.Visible = false;
                btnVolverjugar.Visible = true;
                btnRegresarSeleccion.Visible = true;
                lblGanador.Text = "Gano el Jugador 2";
                lblGanador.Visible = true;
            }
        }
        private void btnCartaSiguiente_Click(object sender, EventArgs e)
        {
            this.control.CartaSiguiente();
            pintarTablerosJuego();
            verificarGanador();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.control.RestablecerImagenesCartas();
            generarTablasAleatorias();
            lblGanador.Visible = false;
            pnlJuego.Visible = false;
            pnlMenuPrincipal.Visible = true;
        }

        private void btnVolverjugar_Click(object sender, EventArgs e)
        {
            this.control.IniciarJuego();
            lblGanador.Visible = false;
            this.btnRegresarSeleccion.Visible = false;
            this.btnCartaSiguiente.Visible = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            generarTablasAleatorias();
            
        }
    }
}
