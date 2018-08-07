using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    class Matriz : Grafo {

        private const float SIN_CONECTAR = 0;

        private Nodo[] nodos;
        private float[,] aristas;

        public Matriz(int numNodos) {
            this.aristas = new float[numNodos, numNodos];
            this.nodos = new Nodo[numNodos];

            for (int x = 0; x < numNodos; x++) {
                for (int y = 0; y < numNodos; y++) {
                    this.aristas[x, y] = SIN_CONECTAR;
                    Nodo nodo = new Nodo(nodos.Count + 1, x, y);
                    this.nodos[x] = nodo;
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

        public float GetDistancia(int id1, int id2) {
            return aristas[id1, id2];
        }

        public Boolean IsConectados(int idNodo1, int idNodo2) {
            return aristas[idNodo1, idNodo2] != SIN_CONECTAR;
        }

        public List<int> GetAdyacentes(int idNodo) {
            List<int> adyacentes = new List<int>();

            for (int i = 0; i < nodos.Count; i++) {
                if (IsConectados(idNodo, i)) {
                    adyacentes.Add(i);
                }
            }
            return adyacentes;
        }

        public void AddArista(Nodo n1, Nodo n2) {
            throw new NotImplementedException();
        }

        public void RemoveArisa(Nodo n1, Nodo n2) {
            throw new NotImplementedException();
        }

        public List<Nodo> GetVecinos(Nodo nodo) {
            List<Nodo> vecinos = new List<Nodo>();
            for (int i = 0; i < aristas.GetLength(0); i++) {
                if (aristas[nodo.ID, i] != SIN_CONECTAR) {
                    vecinos.Add(nodos[i]);
                }
            }

            return vecinos;
        }

        public float Distancia(Nodo n1, Nodo n2) {
            return aristas[n1.ID, n2.ID];
        }
    }

}
