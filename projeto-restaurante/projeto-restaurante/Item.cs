using System;

namespace projeto_restaurante
{
    public class Item
    {
        private int id = 0;
        private string descricao;
        private double preco;

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public double Preco { get => preco; set => preco = value; }

        public Item(string descricao, double preco)
        {
            this.descricao = descricao;
            this.preco = preco;
        }
        public Item() { }
    }
}
