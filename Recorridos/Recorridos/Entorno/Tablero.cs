using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Entorno {
    class Tablero {
        public enum Estado {libre, ocupado, visitado, origen, destino};

        private Estado[,] casillas;

        // Nodo de origen y de destino
        private int[] origen;
        private int[] destino;
        private int ancho;
        private int alto;

        public Tablero(int ancho, int alto) {
            this.ancho = ancho;
            this.alto = alto;

            casillas = new Estado[ancho, alto];
            
            for (int x = 0; x < ancho; x++) {
                for (int y = 0; y < alto; y++) {
                    casillas[x, y] = Estado.libre;
                }
            }
        }

        public Estado GetEstado(int x, int y) {
            return casillas[x, y];
        }

        public void SetEstado(int x, int y, Estado estado) {
             casillas[x, y] = estado;
        }

        public int Ancho {
            get { return ancho; }
            set { this.ancho = value; }
        }

        public int Alto {
            get { return alto; }
            set { this.alto = value; }
        }

        public int[] Origen {
            get { return origen; }
            set { origen = value; }
        }

        public int[] Destino {
            get { return destino; }
            set { destino = value; }
        }

        /// <summary>
        /// Transforma la posición x, y en un ID secuencial
        /// </summary>
        public int GetId(int x, int y) {
            return x + y * ancho;
        }

        public int GetXY(int id) {
            int x = id % ancho;
            int y =(int)(id / ancho);

            return 0;
        }

        /// <summary>
        /// Devuelve la lista de casillas adyacentes (como máximo devuelve 8).
        /// </summary>
        /// <returns></returns>
        public List<int> Vecinos(int x, int y) {
            List<int> adyacentes = new List<int>();

            for (int i = x-1; i <= x + 1; i++) {
                if (i >= 0 && i < ancho) {
                    for (int j = y - 1; j <= y + 1; j++) {
                        if (j >= 0 && j < ancho && x != i && y != j) 
                            adyacentes.Add(GetId(i, j));                        
                    }
                }
            }

            return adyacentes;
        }



    }
}
