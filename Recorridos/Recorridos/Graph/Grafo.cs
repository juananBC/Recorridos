using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    class Grafo {

        private const float SIN_CONECTAR = 0;

        private HashSet<Nodo> nodos;
        private float[,] aristas;

        public Grafo(int numNodos) {
            this.aristas = new float[numNodos, numNodos];
            this.nodos = new HashSet<Nodo>();

            for (int x = 0; x < numNodos; x++) {
                for (int y = 0; y < numNodos; y++) {
                    this.aristas[x, y] = SIN_CONECTAR;
                    Nodo nodo = new Nodo(x, y);
                    this.nodos.Add(nodo);
                }
            }

        }

        public void AddArista(int id1, int id2, float distancia) {
            aristas[id1, id2] = distancia;
            aristas[id2, id1] = distancia;
        }

        public void RemoveArista(int id1, int id2) {
            aristas[id1, id2] = SIN_CONECTAR;
            aristas[id2, id1] = SIN_CONECTAR;
        }

        public float GetDistancia(int id1, int id2){
           return aristas[id1, id2]; 
        }





    }

}
