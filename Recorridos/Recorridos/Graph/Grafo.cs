using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recorridos.Recorridos.Graph {

    interface Grafo {

        void AddArista(Nodo n1, Nodo n2);
        void RemoveArisa(Nodo n1, Nodo n2);
        List<Nodo> GetVecinos(Nodo nodo);
        float Distancia(Nodo n1, Nodo n2);
      
    }

}
