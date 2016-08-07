using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLoteria
{
    class Carta
    {
        PictureBox picturebox;
        private String nombre;
        private String ruta;
        private Point size;
        private Point location;
        private int posicion;
        private bool visible;
        private Graphics gp;

        public PictureBox Picturebox
        {
            get
            {
                return picturebox;
            }

            set
            {
                picturebox = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Ruta
        {
            get
            {
                return ruta;
            }

            set
            {
                ruta = value;
            }
        }

        public int Posicion
        {
            get
            {
                return posicion;
            }

            set
            {
                posicion = value;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }

            set
            {
                visible = value;
            }
        }

        public Point Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public Point Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public Carta()
        {

        }
        public Carta(string nombre, string ruta, int posicion, bool visible)
        {
            location = new Point(0, 0);
            size = new Point(0, 0);
            picturebox = new PictureBox();
            picturebox.Image = Image.FromFile(ruta);
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.BackColor = Color.Black;
            picturebox.Size = new Size(200,200);
            picturebox.Location = new Point(0,0);
            picturebox.Visible = true;
            Nombre = nombre;
            Ruta = ruta;
            //gp = picturebox.CreateGraphics();
            //Font drawFont = new Font("Arial", 16);
            //gp.DrawString("1", drawFont, new SolidBrush(Color.Black),new Point(0,0));
            this.Posicion = posicion;
            this.Visible = visible;

        }
        public void  pintar(int tamaño,Point posicion)
        {
            gp = picturebox.CreateGraphics();
            Font drawFont = new Font("Arial", tamaño);
            gp.DrawString(nombre, drawFont, new SolidBrush(Color.Black), posicion);
        }
        public Carta(string nombre, int posicion, bool visible)
        {
            size = new Point(0,0);
            location = new Point(0,0);
            picturebox = new PictureBox();
            picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            picturebox.BackColor = Color.Black;
            picturebox.Size = new Size(200, 200);
            picturebox.Location = new Point(0, 0);
            Nombre = nombre;
            this.Posicion = posicion;
            this.Visible = visible;
        }
    }
}
