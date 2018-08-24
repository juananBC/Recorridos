using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    class Nodo {

        private static int IDS = 0;

        private int id;
        // Posiciones en el espacio 2D.
        private int x, y;
        private Estado estado;

        public Nodo(int id, int x, int y) {
            this.x = x;
            this.y = y;
            this.estado = Estado.libre;
            this.id = id;
        }
        
        // GETTERS y SETTERS
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int ID { get => id; set => id = value; }
        public Estado Estado { get => estado; set => estado = value; }


    }
}
