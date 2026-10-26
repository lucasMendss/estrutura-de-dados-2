using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_medicamentos
{
    internal class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        public Queue<Lote> Lotes { get => lotes; set => lotes = value; }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            this.lotes = new Queue<Lote>();
        }

        public int QtdeDisponivel()
        {
            int soma = 0;
            foreach (Lote lote in this.lotes)
            {
                soma += lote.Qtde;
            }
            return soma;
        }

        public void Comprar(Lote lote)
        {
            this.lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (qtde <= 0 || this.QtdeDisponivel() < qtde)
            {
                return false;
            }

            int restante = qtde;
            while (restante > 0)
            {
                Lote loteAtual = this.lotes.Peek();
                if (loteAtual.Qtde <= restante)
                {
                    restante -= loteAtual.Qtde;
                    this.lotes.Dequeue();
                }
                else
                {
                    loteAtual.Qtde -= restante;
                    restante = 0;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return this.id + "-" + this.nome + "-" + this.laboratorio + "-" + this.QtdeDisponivel();
        }

        public override bool Equals(object obj)
        {
            Medicamento outro = obj as Medicamento;
            return outro != null && this.id == outro.id;
        }

        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }
    }
}
