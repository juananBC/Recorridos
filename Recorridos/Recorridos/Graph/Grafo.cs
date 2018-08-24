using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    abstract class Grafo {

         private Nodo[] nodos;

        public void PonerObstaculo(int id) {
            Nodo nodoRemove = GetNodo(id);
            nodoRemove.Estado = Estado.ocupado;
            List<int> vecinos = GetVecinos(id);

            for (int i = 0; i < vecinos.Count; i++) {
                RemoveArista(nodoRemove, Nodos[vecinos[i]]);
            }


        }


        public Nodo GetNodo(int id) {
            if (id < 0 || id >= Nodos.Length) return null;
            return Nodos[id];
        }


        public Nodo[] Nodos {
            get => nodos; set => nodos = value;
        }
        public abstract void AddArista(int id1, int id2, float distancia);
        public abstract void RemoveArista(Nodo n1, Nodo n2);
        public abstract List<int> GetVecinos(int idNodo);

        /// <summary>
        /// Devuelve la distancia de dos nodos conectados
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <returns></returns>
        public abstract float Distancia(int id1, int id2);
        public abstract bool IsConectado(int id1, int id2);
        public override abstract String ToString();

      
    }

}
