using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLoteria
{
    class Tabla
    {
        private int alto;
        private int largo;
        private List<Carta> cartas;
        //private Point Location;
        public int Alto
        {
            get
            {
                return alto;
            }

            set
            {
                alto = value;
            }
        }

        public int Largo
        {
            get
            {
                return largo;
            }

            set
            {
                largo = value;
            }
        }

        internal List<Carta> Cartas
        {
            get
            {
                return cartas;
            }

            set
            {
                cartas = value;
            }
        }

        //public void actualizarCartas()
        //{
        //    foreach (var item in cartas)
        //    {
        //        item.Location = Location;
        //        item.Size = new Point(largo,alto);
        //        item.actualizarPictureBox();
                
        //    }
        //}
        public Tabla(int alto, int largo, List<Carta> cartas)
        {
            this.Alto = alto;
            this.Largo = largo;
            this.Cartas = cartas;
            //this.Location = new Point();
        }

        public Tabla()
        {

        }

        public Tabla(List<Carta> cartas, Point size)
        {
            this.cartas = cartas;
            this.largo = size.X;
            this.alto = size.Y;
            //this.Location = new Point();

        }
    }
}
