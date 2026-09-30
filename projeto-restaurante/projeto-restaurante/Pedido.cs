using System;
using System.Linq;
using System.Collections.Generic;

namespace projeto_restaurante
{
    public class Pedido
    {
        private int id = 0;
        private string cliente;
        private Item[] itens = new Item[10];

        // gerenciamento por ID lógico separado da posição
        private int nextItemId = 1;
        private Dictionary<int, int> itemIdToIndex = new Dictionary<int, int>(); // itemId -> índice no array
        private List<int> freeItemSlots = new List<int>();

        public int Id { get => id; set => id = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public Item[] Itens { get => itens; }

        public Pedido(string cliente)
        {
            this.cliente = cliente;
        }

        public bool adicionarItem(Item item)
        {
            if (item == null) return false;

            int idx;
            if (freeItemSlots.Count > 0)
            {
                idx = freeItemSlots[freeItemSlots.Count - 1];
                freeItemSlots.RemoveAt(freeItemSlots.Count - 1);
            }
            else
            {
                idx = Array.FindIndex(itens, i => i == null);
                if (idx == -1) return false; // cheio
            }

            item.Id = nextItemId++;
            itens[idx] = item;
            itemIdToIndex[item.Id] = idx;
            return true;
        }

        public bool removerItem(Item item)
        {
            if (item == null) return false;
            if (!itemIdToIndex.TryGetValue(item.Id, out int idx)) return false;

            itens[idx] = null; // remoção lógica
            itemIdToIndex.Remove(item.Id);
            freeItemSlots.Add(idx);
            return true;
        }

        public string dadosDoPedido()
        {
            return "Pedido: #" + id + "\n" +
                  "- Cliente: " + cliente + "\n" +
                  "- Itens:\n" + string.Join("\n", itens.Where(i => i != null).Select(i => " - [" + i.Id + "] " + i.Descricao + " (R$ " + i.Preco + ")")) + "\n" +
                  "- Total: R$ " + calcularTotal();
        }

        public double calcularTotal()
        {
            double precoTotal = 0;
            foreach (Item item in itens)
            {
                if (item != null)
                {
                    precoTotal += item.Preco;
                }
            }
            return precoTotal;
        }

        public override bool Equals(object obj)
        {
            return obj is Pedido pedido &&
                   id == pedido.id &&
                   cliente == pedido.cliente;
        }
    }
}
