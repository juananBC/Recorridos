using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    class NodoLista {
        private int id;
        private NodoLista next;
        private float distancia;

        public NodoLista(int id,  float distancia) {
            this.Distancia = distancia;
            this.Next = null;
            this.Id = id;
        }

        public NodoLista(int id, NodoLista next, float distancia) {
            this.Id = id;
            this.Next = next;
            this.Distancia = distancia;
        }

        public int Id { get => id; set => id = value; }
        public float Distancia { get => distancia; set =>distancia = value; }
        internal NodoLista Next { get => next; set => next = value; }
    }

    class Lista : Grafo {

        private int numNodos;
        private NodoLista[] listaNodos;

        public Lista(int ancho, int largo) {
            numNodos = ancho * largo;
            this.Nodos = new Nodo[numNodos];
            this.listaNodos = new NodoLista[numNodos];

            for (int id = 0; id < numNodos; id++) {
                int x = id % ancho;
                int y = (int)(id / ancho);

                Nodo nodo = new Nodo(id, x, y);
                this.Nodos[id] = nodo;
                this.listaNodos[id] = null; 
            }

        }

        public override void AddArista(int id1, int id2, float distancia) {
            AddAristaUnidireccion(id1, id2, distancia);
            AddAristaUnidireccion(id2, id1, distancia);
        }

        private void AddAristaUnidireccion(int id1, int id2, float distancia) {
            NodoLista nodo = listaNodos[id1];
            if (nodo == null) {
                listaNodos[id1] = new NodoLista(id2, distancia);
                nodo = listaNodos[id1];
            } else {
                while (nodo.Next != null && nodo.Next.Id != id2) {
                    nodo = nodo.Next;
                }
                if (nodo.Next == null) {
                    nodo.Next = new NodoLista(id2, distancia);
                }
            }
        }

        public override void RemoveArista(Nodo n1, Nodo n2) {
            int id1 = n1.ID;
            int id2 = n2.ID;

            RemoveAristaUnidireccion(id1, id2);
            RemoveAristaUnidireccion(id2, id1);

        }

        private void RemoveAristaUnidireccion(int id1, int id2) {
            NodoLista nodo1 = listaNodos[id1];
            while (nodo1 != null && nodo1.Next != null) {
                if (nodo1.Next.Id == id2) {
                    nodo1.Next = nodo1.Next.Next;
                }
            }
        }
        public override float Distancia(int id1, int id2) {

            NodoLista nodo = listaNodos[id1];
            while (nodo != null) {
                if (nodo.Id == id2)
                    return nodo.Distancia;
                nodo = nodo.Next;
            }

            return SIN_CONECTAR;
        }


        public override List<int> GetVecinos(int idNodo) {
            List<int> vecinos = new List<int>();

            NodoLista nodo = listaNodos[idNodo];
            while (nodo != null) {
                if(nodo.Id != idNodo) 
                    vecinos.Add(nodo.Id);

                nodo = nodo.Next;
            }

            return vecinos;
        }

        public override bool IsConectado(int id1, int id2) {
            NodoLista nodo1 = listaNodos[id1];
            while (nodo1 != null) {
                if (nodo1.Id == id2) {
                    return true;
                }
                nodo1 = nodo1.Next;
            }

            return false;

        }     

        public override string ToString() {
            String resultado = "";

            for (int i = 0; i < this.listaNodos.Length; i++) {
                resultado += "Nodo " + i + ": ";
                NodoLista nodo = this.listaNodos[i];
                while (nodo != null) {
                    resultado += nodo.Id + "(" + nodo.Distancia + "),  ";
                    nodo = nodo.Next;
                }
                resultado += "\n";
            }

            return resultado;
        }
    }
}
