using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProyectoLoteria
{
    class Controlador
    {
        private List<Carta> cartas;
        private List<Tabla> tablasPredeterminadas;
        private Tabla tablaJugador1;
        private Tabla tablaJugador2;
        private Tabla tablaPrincipal;
        private Carta cartaPrincipal;
        private Carta cartaVacia;
        private int numCartaAcual;
        public List<int> ordenCartas;
        private bool jugador1;
        private bool ganoJugador1;
        private bool ganoJugador2;
        int numCartasDestapadas1;
        int numCartasDestapadas2;

        public Controlador()
        {
            Cartas = new List<Carta>();
            jugador1 = true;
            TablasPredeterminadas = new List<Tabla>();
            TablaJugador1 = new Tabla();
            TablaJugador2 = new Tabla();
            CartaPrincipal = new Carta();
            CartaVacia = new Carta();
            TablaPrincipal = new Tabla();
            numCartaAcual = 0;
            ganoJugador1 = false;
            ganoJugador2 = false;


        }


        public void RestablecerImagenesCartas()
        {

            cartaPrincipal.ActualizarRuta("55");
            for (int i = 0; i < 54; i++)
            {
                //MessageBox.Show("entro");
                TablaPrincipal.Cartas[i].ActualizarRuta(TablaPrincipal.Cartas[i].Ruta);
            }
            for (int i = 0; i < 6; i++)
            {

                tablaJugador1.Cartas[i].ActualizarRuta(tablaJugador1.Cartas[i].Ruta);
            }
            if (jugador1 == false)
            {
                for (int i = 0; i < 6; i++)
                {
                    tablaJugador2.Cartas[i].ActualizarRuta(tablaJugador2.Cartas[i].Ruta);

                }

            }
            
        }
        public void IniciarJuego()
        {
            numCartaAcual = 0;
            ganoJugador1 = false;
            ganoJugador2 = false;
            numCartasDestapadas1 = 0;
            numCartasDestapadas2 = 0;
            RestablecerImagenesCartas();
            ordenCartas = generar54Numeros();
            //MessageBox.Show(obtenerCarta(ordenCartas[4]).Nombre);

            //MessageBox.Show(cartaPrincipal.Nombre);
        }


        public void CartaSiguiente()
        {
            //MessageBox.Show(""+ numCartaAcual);
            if (numCartaAcual < 54)
            {
                cartaPrincipal.ActualizarRuta(obtenerCarta(ordenCartas[numCartaAcual]).Ruta);
               
                verificarJuego(obtenerCarta(ordenCartas[numCartaAcual]).Posicion);
            }
            numCartaAcual++;


        }
        //private Carta obtenerCarta2(int posCarta, )
        //{
        //    Carta aux = Cartas.ElementAt(posCarta);

        //    Carta carta = new Carta(aux.Nombre, aux.Ruta, aux.Posicion, aux.Visible);

        //    return carta;
        //}
        private void verificarJuego(int numCarta)
        {
            for (int i = 0; i < 54; i++)
            {
                if (TablaPrincipal.Cartas[i].Posicion == numCarta)
                {
                    //MessageBox.Show("entro");
                    TablaPrincipal.Cartas[i].ActualizarRuta("55");
                    break;

                }
            }
            if (jugador1)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (tablaJugador1.Cartas[i].Posicion == numCarta)
                    {
                       // MessageBox.Show("entro");
                        tablaJugador1.Cartas[i].ActualizarRuta("55");
                        numCartasDestapadas1++;
                        break;

                    }

                }
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    if (tablaJugador1.Cartas[i].Posicion == numCarta)
                    {
                       // MessageBox.Show("entro");
                        tablaJugador1.Cartas[i].ActualizarRuta("55");
                        numCartasDestapadas1++;
                        break;

                    }

                }
                for (int i = 0; i < 6; i++)
                {
                    if (tablaJugador2.Cartas[i].Posicion == numCarta)
                    {
                       // MessageBox.Show("entro");
                        tablaJugador2.Cartas[i].ActualizarRuta("55");
                        numCartasDestapadas2++;
                        break;

                    }

                }

            }
            if (numCartasDestapadas1 == 6)
            {
                GanoJugador1 = true;
                numCartaAcual = 54;
            }

            if (numCartasDestapadas2 == 6)
            {
                numCartaAcual = 54;
                ganoJugador2 = true;

            }

        }


        public void crearCartas()
        {
            //Cartas.Add(new Carta("El gallo", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\1.JPG", 1, true));
            //Cartas.Add(new Carta("El diablito", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\2.JPG", 2 , true));
            //Cartas.Add(new Carta("La dama", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\3.JPG", 3 , true));
            //Cartas.Add(new Carta("El catrin", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\4.JPG", 4 , true));
            //Cartas.Add(new Carta("El paraguas", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\5.JPG", 5 , true));
            //Cartas.Add(new Carta("La sirena", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\6.JPG", 6, true));
            //Cartas.Add(new Carta("La escalera", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\7.JPG", 7 , true));
            //Cartas.Add(new Carta("La botella", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\8.JPG", 8 , true));
            //Cartas.Add(new Carta("El barril", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\9.JPG", 9 , true));
            //Cartas.Add(new Carta("El arbol", @"C:\Users\HéctorEdgar\Desktop\Proyectos Laboratorio de aplicaciones empresariales\Aplicaciones-Empresariales\ProyectoLoteria\ImagenesLoteria\10.JPG", 10 , true));
            Cartas.Add(new Carta("El gallo", "1", 1, true));
            Cartas.Add(new Carta("El diablito", "2", 2, true));
            Cartas.Add(new Carta("La dama", "3", 3, true));
            Cartas.Add(new Carta("El catrin", "4", 4, true));
            Cartas.Add(new Carta("El paraguas", "5", 5, true));
            Cartas.Add(new Carta("La sirena", "6", 6, true));
            Cartas.Add(new Carta("La escalera", "7", 7, true));
            Cartas.Add(new Carta("La botella", "8", 8, true));
            Cartas.Add(new Carta("El barril", "9", 9, true));
            Cartas.Add(new Carta("El arbol", "10", 10, true));
            Cartas.Add(new Carta("El melon", "11", 11, true));
            Cartas.Add(new Carta("El valiente", "12", 12, true));
            Cartas.Add(new Carta("El gorrito", "13", 13, true));
            Cartas.Add(new Carta("La muerte", "14", 14, true));
            Cartas.Add(new Carta("La pera", "15", 15, true));
            Cartas.Add(new Carta("La bandera", "16", 16, true));
            Cartas.Add(new Carta("El bandolon", "17", 17, true));
            Cartas.Add(new Carta("El violoncello", "18", 18, true));
            Cartas.Add(new Carta("La garza", "19", 19, true));
            Cartas.Add(new Carta("El pajaro", "20", 20, true));
            Cartas.Add(new Carta("La mano", "21", 21, true));
            Cartas.Add(new Carta("La bota", "22", 22, true));
            Cartas.Add(new Carta("La luna", "23", 23, true));
            Cartas.Add(new Carta("El cotorro", "24", 24, true));
            Cartas.Add(new Carta("El borracho", "25", 25, true));
            Cartas.Add(new Carta("El negrito", "26", 26, true));
            Cartas.Add(new Carta("El corazon", "27", 27, true));
            Cartas.Add(new Carta("La sandia", "28", 28, true));
            Cartas.Add(new Carta("El tambor", "29", 29, true));
            Cartas.Add(new Carta("El camaron", "30", 30, true));
            Cartas.Add(new Carta("Las jaras", "31", 31, true));
            Cartas.Add(new Carta("El musico", "32", 32, true));
            Cartas.Add(new Carta("La araña", "33", 33, true));
            Cartas.Add(new Carta("El soldado", "34", 34, true));
            Cartas.Add(new Carta("La estrella", "35", 35, true));
            Cartas.Add(new Carta("El cazo", "36", 36, true));
            Cartas.Add(new Carta("El mundo", "37", 37, true));
            Cartas.Add(new Carta("El apache", "38", 38, true));
            Cartas.Add(new Carta("El nopal", "39", 39, true));
            Cartas.Add(new Carta("El alacran", "40", 40, true));
            Cartas.Add(new Carta("La rosa", "41", 41, true));
            Cartas.Add(new Carta("La calavera", "42", 42, true));
            Cartas.Add(new Carta("La campana", "43", 43, true));
            Cartas.Add(new Carta("El cantarito", "44", 44, true));
            Cartas.Add(new Carta("El venado", "45", 45, true));
            Cartas.Add(new Carta("El sol", "46", 46, true));
            Cartas.Add(new Carta("La corona", "47", 47, true));
            Cartas.Add(new Carta("La chalupa", "48", 48, true));
            Cartas.Add(new Carta("El pino", "49", 49, true));
            Cartas.Add(new Carta("El pescado", "50", 50, true));
            Cartas.Add(new Carta("La palma", "51", 51, true));
            Cartas.Add(new Carta("La maceta", "52", 52, true));
            Cartas.Add(new Carta("El arpa", "53", 53, true));
            Cartas.Add(new Carta("La rana", "54", 54, true));
            cartaVacia = new Carta("Defaulth", "55", 55, false);
            cartaVacia.Size = new Point(131, 166);
            cartaVacia.Location = new Point(0, 0);
            cartaVacia.actualizarPictureBox();
            CartaPrincipal = new Carta("Defaulth", "55", 55, true);
            CartaPrincipal.Size = new Point(131, 166);
            CartaPrincipal.Location = new Point(0, 0);
            CartaPrincipal.actualizarPictureBox();
            Cartas.Add(new Carta("Defaulth", "55", 55, true));

        }
        public int VerificarNumerosGanadores(int[] numerosGanadores, List<int> numerosJugados)
        {
            int numeroAciertos = 0;
            for (int i = 0; i < 7; i++)
            {
                foreach (int numeroJugado in numerosJugados)
                {
                    if (numerosGanadores[i] == numeroJugado)
                    {
                        numeroAciertos++;

                    }

                }
            }

            return numeroAciertos;
        }

        public Carta obtenerCarta(int posCarta)
        {
            Carta aux = Cartas.ElementAt(posCarta);

            Carta carta = new Carta(aux.Nombre, aux.Ruta, aux.Posicion, aux.Visible);

            return carta;
        }
        public void crearTablasPredeterminadas(int numTablas, int MaxNumCartas, Point size)
        {
            TablasPredeterminadas = new List<Tabla>();
            for (int i = 0; i < numTablas; i++)
            {
                TablasPredeterminadas.Add(crearTablaAleatoria2X3(MaxNumCartas, size));
            }



        }
        public void CrearTablaPrincipal9X6(Size size)
        {
            int incrX = size.Width / 6;
            int incrY = size.Height / 9;

            int posx;
            int posy = 0;
            int cont = 0;
            List<Carta> cartasTablero = new List<Carta>();
            Carta aux;
            for (int i = 0; i < 9; i++)
            {
                posx = 0;
                for (int j = 0; j < 6; j++)
                {

                    aux = obtenerCarta(cont++);
                    aux.Size = new Point(incrX, incrY);
                    aux.Location = new Point(posx, posy);
                    aux.actualizarPictureBox();
                    cartasTablero.Add(aux);

                    posx = posx + incrX;
                }
                posy = posy + incrY;
            }

            this.TablaPrincipal.Cartas = cartasTablero;
        }

        public void SeleccionarTablaJugador1(int tabla)
        {



            Tabla aux = tablasPredeterminadas.ElementAt(tabla-1);
            this.tablaJugador1 = new Tabla(aux.Alto, aux.Largo, aux.Cartas);

        }
        public void SeleccionarTablaJugador2(int tabla)
        {
            Tabla aux = tablasPredeterminadas.ElementAt(tabla-1);
            this.tablaJugador2 = new Tabla(aux.Alto, aux.Largo, aux.Cartas);
        }
        private Tabla crearTablaAleatoria2X3(int maxNum, Point size)
        {
            List<Carta> cartasTablero = new List<Carta>();
            Carta[] cartas = new Carta[maxNum];
            List<int> numerosAleatorios = generarNumerosAleatorios(6, maxNum);
            int incrX = size.X / 2;
            int incrY = size.Y / 3;

            int posx;
            int posy = 0;
            int cont = 0;
            foreach (int numCarta in numerosAleatorios)
            {
                cartas[cont++] = obtenerCarta(numCarta);
            }
            cont = 0;

            for (int i = 0; i < 3; i++)
            {
                posx = 0;

                for (int j = 0; j < 2; j++)
                {
                    cartas[cont].Size = new Point(incrX, incrY);
                    cartas[cont].Location = new Point(posx, posy);
                    cartas[cont].actualizarPictureBox();
                    //MessageBox.Show(""+ cartas[cont].Nombre+"  "+ cartas[cont].Size);
                    cartasTablero.Add(cartas[cont]);
                    cont++;
                    posx = posx + incrX;

                }
                posy = posy + incrY;
            }
            //foreach (int numeroCarta in numerosAleatorios)
            //{

            //    Carta carta = obtenerCarta(numeroCarta);
            //    carta.Size = new Point(incrX,incrY);
            //    carta.Location = new Point(posx,posy);
            //    cartas.Add(carta);



            //}


            return new Tabla(cartasTablero, size);
        }

        private List<int> generarNumerosAleatorios(int numNumeros, int maxNum)
        {
            bool bandera;
            bool hayRepetidos;
            bool hayCero;
            int[] numeros = new int[numNumeros];
            List<int> valores = new List<int>();
            Random rd = new Random(DateTime.Now.TimeOfDay.Milliseconds);

            for (int i = 0; i < numNumeros; i++)
            {
                bandera = true;
                hayRepetidos = false;

                while (bandera)
                {
                    hayCero = true;
                    while (hayCero)
                    {
                        numeros[i] = rd.Next(maxNum);
                        if (numeros[i] != 0)
                        {
                            hayCero = false;
                        }
                    }


                    foreach (int valor in valores)
                    {
                        if (numeros[i] == valor)
                        {
                            hayRepetidos = true;
                            break;
                        }
                    }

                    if (hayRepetidos)
                    {
                        hayRepetidos = false;
                    }
                    else
                    {
                        bandera = false;
                        valores.Add(numeros[i]);
                    }
                }

            }



            return valores;
        }


        public List<int> generar54Numeros()
        {
            List<int> valores = new List<int>();
            Random rd = new Random(DateTime.Now.TimeOfDay.Milliseconds);
            bool bandera = false;
            bool hayCero;
            bool hayRepetidos = false;
            int aux = 0;
            int cont = 0;
            for (int i = 0; i < 54; i++)
            {
                bandera = true;
                while (bandera)
                {



                    aux = rd.Next(54);



                    foreach (int valor in valores)
                    {
                        if (aux == valor)
                        {
                            hayRepetidos = true;
                            break;
                        }
                    }

                    if (hayRepetidos)
                    {
                        hayRepetidos = false;
                    }
                    else
                    {
                        //MessageBox.Show(""+(cont++)+"---"+aux);
                        valores.Add(aux);
                        bandera = false;
                    }
                }
            }



            return valores;
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

        internal List<Tabla> TablasPredeterminadas
        {
            get
            {
                return tablasPredeterminadas;
            }

            set
            {
                tablasPredeterminadas = value;
            }
        }

        internal Tabla TablaJugador1
        {
            get
            {
                return tablaJugador1;
            }

            set
            {
                tablaJugador1 = value;
            }
        }

        internal Tabla TablaJugador2
        {
            get
            {
                return tablaJugador2;
            }

            set
            {
                tablaJugador2 = value;
            }
        }

        internal Tabla TablaPrincipal
        {
            get
            {
                return tablaPrincipal;
            }

            set
            {
                tablaPrincipal = value;
            }
        }

        internal Carta CartaPrincipal
        {
            get
            {
                return cartaPrincipal;
            }

            set
            {
                cartaPrincipal = value;
            }
        }

        internal Carta CartaVacia
        {
            get
            {
                return cartaVacia;
            }

            set
            {
                cartaVacia = value;
            }
        }

        public bool Jugador1
        {
            get
            {
                return jugador1;
            }

            set
            {
                jugador1 = value;
            }
        }

        public bool GanoJugador1
        {
            get
            {
                return ganoJugador1;
            }

            set
            {
                ganoJugador1 = value;
            }
        }

        public bool GanoJugador2
        {
            get
            {
                return ganoJugador2;
            }

            set
            {
                ganoJugador2 = value;
            }
        }
    }
}
