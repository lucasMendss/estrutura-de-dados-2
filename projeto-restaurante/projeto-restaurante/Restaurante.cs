using System;
using System.Collections.Generic;
using System.Linq;

namespace projeto_restaurante
{
    public static class Restaurante
    {
        // id lógico crescente separado da posição física no array
        static private int nextId = 1;
        static private Pedido[] pedidos = new Pedido[50];
        static private List<int> freeSlots = new List<int>();
        static private Dictionary<int, int> idToIndex = new Dictionary<int, int>(); // id -> índice

        static public Pedido[] Pedidos { get => pedidos; }

        public static bool novoPedido(Pedido pedido)
        {
            if (pedido == null) return false;

            int idx;
            if (freeSlots.Count > 0)
            {
                idx = freeSlots[freeSlots.Count - 1];
                freeSlots.RemoveAt(freeSlots.Count - 1);
            }
            else
            {
                idx = Array.FindIndex(pedidos, p => p == null);
                if (idx == -1) return false; // array cheio
            }

            pedido.Id = nextId++;
            pedidos[idx] = pedido;
            idToIndex[pedido.Id] = idx;
            return true;
        }

        public static Pedido buscarPedido(Pedido pedido)
        {
            if (pedido == null) return null;
            if (idToIndex.TryGetValue(pedido.Id, out int idx))
                return pedidos[idx];
            return null;
        }

        public static bool cancelarPedido(Pedido pedido)
        {
            if (pedido == null) return false;
            if (!idToIndex.TryGetValue(pedido.Id, out int idx)) return false;

            pedidos[idx] = null; // remoção lógica sem transpor
            idToIndex.Remove(pedido.Id);
            freeSlots.Add(idx);
            return true;
        }
    }
}
