using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Entorno {
    class Tablero {
        private int ancho, largo;
        public enum Estado {libre, ocupado, visitado, origen, destino};

        private Estado[,] casillas;

        public Tablero(int ancho, int alto) {
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

        public int Largo {
            get { return largo; }
            set { this.largo = value; }
        }

    }
}
