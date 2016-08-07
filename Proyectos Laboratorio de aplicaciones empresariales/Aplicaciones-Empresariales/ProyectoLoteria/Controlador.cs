using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLoteria
{
    class Controlador
    {
        List<Carta> cartas;
        List<Tabla> tablasPredeterminadas;
        Tabla tablaJugador1;
        Tabla tablaJugador2;
        Tabla tablaPrincipal;
        Carta cartaPrincipal;

        public Controlador()
        {
            cartas = new List<Carta>();
            tablasPredeterminadas = new List<Tabla>();
            tablaJugador1 = new Tabla();
            tablaJugador2 = new Tabla();
            cartaPrincipal = new Carta();
            tablaPrincipal = new Tabla();

        }

        public void crearCartas(int numCartas)
        {
            for (int i = 0; i < numCartas; i++)
            {
                cartas.Add(new Carta(""+i,i,true));
            }
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
            return cartas.ElementAt(posCarta);
        }
        public void crearTablasPredeterminadas(int numTablas, int MaxNumCartas, Point size)
        {
            for (int i = 0; i < numTablas; i++)
            {
                tablasPredeterminadas.Add(crearTablaAleatoria2X3(MaxNumCartas,size));
            }

           

        }
        public Tabla crearTablaAleatoria2X3(int maxNum,Point size)
        {
            List<Carta> cartasTablero = new List<Carta>();
            Carta[] cartas = new Carta[6];
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
                    cartas[cont].Size = new Point(posx, posy);
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

        public List<int> generarNumerosAleatorios(int numNumeros,int maxNum)
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
                    
                    numeros[i] = rd.Next(maxNum);
                    
                    foreach (int valor in valores)
                    {
                        if (numeros[i] == valor)
                        {
                            hayRepetidos = true;
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

    }
}
