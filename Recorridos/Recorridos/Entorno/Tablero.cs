using Recorridos.Recorridos.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Recorridos.Recorridos.Graph.Nodo;

namespace Recorridos.Recorridos.Entorno {
    class Tablero {


        // Nodo de origen y de destino
        private int origen;
        private int destino;
        private int ancho;
        private int alto;
        private Estado[,] casillas;

        public Tablero(int ancho, int alto) {
            this.ancho = ancho;
            this.alto = alto;

            casillas = new Estado[ancho, alto];

            // Inicia casillas
            for (int x = 0; x < ancho; x++) {
                for (int y = 0; y < alto; y++) {
                    casillas[x, y] = Estado.libre;
                }
            }
        }

        public Estado GetEstado(int x, int y) {
            return casillas[x, y];
        }

        public Estado GetEstado(int id) {
            int x = GetX(id);
            int y = GetY(id);

            return casillas[x, y];
        }

        public void SetEstado(int x, int y, Estado estado) {
            if (casillas[x, y] == Estado.origen) Origen = -1;
            if (casillas[x, y] == Estado.destino) Destino = -1;
            casillas[x, y] = estado;
        }

        public void SetEstado(int id, Estado estado) {
            int x = GetX(id);
            int y = GetY(id);
            SetEstado(x, y, estado);
        }

        public int Ancho {
            get { return ancho; }
            set { this.ancho = value; }
        }

        public int Alto {
            get { return alto; }
            set { this.alto = value; }
        }

        public int Origen {
            get { return origen; }
            set { origen = value; }
        }

        public int Destino {
            get => destino; 
            set => destino = value; 
        }
        public Estado[,] Casillas { get => casillas; set => casillas = value; }

        //public Grafo Graph { get => grafo; set => grafo = value; }

        /// <summary>
        /// Transforma la posición x, y en un ID secuencial
        /// </summary>
        public int GetId(int x, int y) {
            return x + y * ancho;
        }

        public int GetX(int id) {
            return id % ancho;
        }

        public int GetY(int id) {
            return (int)(id / ancho);
        }

        public int[] GetXY(int id) {
            int x = id % ancho;
            int y =(int)(id / ancho);

            int[] xy = new int[2];
            xy[0] = x;
            xy[1] = y;

            return xy;
        }

        public float GetDistancia(int id1, int id2) {
            int[] n1 = GetXY(id1);
            int[] n2 = GetXY(id2);

            double X = Math.Pow(n1[0] - n2[0], 2);
            double Y = Math.Pow(n1[1] - n2[1], 2);
            float dist = (float)Math.Sqrt(X + Y);

            return dist;

        }
        /// <summary>
        /// Devuelve la lista de IDs de casillas adyacentes en el tablero (como máximo devuelve 8).
        /// </summary>
        /// <returns></returns>
        public List<int> CasillasAdyacentes(int x, int y) {
            List<int> adyacentes = new List<int>();

            for (int i = x - 1; i <= x + 1; i++) {
                if (i >= 0 && i < ancho) {
                    for (int j = y - 1; j <= y + 1; j++) {
                        if (j >= 0 && j < ancho )
                            adyacentes.Add(GetId(i, j));
                    }
                }
            }

            return adyacentes;
        }

        public void QuitarRecorrido() {
            for (int id = 0; id < Casillas.Length; id++) {
                Estado estado = GetEstado(id);

                if (estado != Estado.ocupado && estado != Estado.destino && estado != Estado.origen)
                    SetEstado(id, Estado.libre);
            }
        }

        /// <summary>
        /// Libera todas las casillas del tablero.
        /// </summary>
        public void Liberar() {
            Origen = -1;
            Destino = -1;
            for (int id = 0; id < Casillas.Length; id++) {
                SetEstado(id, Estado.libre);
            }
        }
    }
}
