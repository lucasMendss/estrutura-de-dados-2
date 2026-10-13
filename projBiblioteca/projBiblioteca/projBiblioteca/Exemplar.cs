using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projBiblioteca
{
    internal class Exemplar
    {
        private int tombo;
        private List<Emprestimo> emprestimos;

        public int Tombo { get => tombo; set => tombo = value; }
        internal List<Emprestimo> Emprestimos { get => emprestimos; set => emprestimos = value; }

        public Exemplar(int tombo)
        {
            this.tombo = tombo;
            this.emprestimos = new List<Emprestimo>();
        }

        public Exemplar() : this(0)
        { }

        public bool disponivel()
        {
            // Disponível se nunca foi emprestado ou se o último empréstimo já foi devolvido
            if (this.emprestimos.Count == 0)
            {
                return true;
            }
            return this.emprestimos[this.emprestimos.Count - 1].Devolvido();
        }

        public bool emprestar()
        {
            if (!disponivel())
            {
                return false;
            }
            this.emprestimos.Add(new Emprestimo());
            return true;
        }

        public bool devolver()
        {
            if (disponivel())
            {
                return false;
            }
            this.emprestimos[this.emprestimos.Count - 1].DtDevolucao = DateTime.Now;
            return true;
        }

        public int qtdeEmprestimos()
        {
            return this.emprestimos.Count;
        }

        public override string ToString()
        {
            return "Tombo = " + this.tombo.ToString() + " (" + (disponivel() ? "disponível" : "emprestado") + ")";
        }

        public override bool Equals(object obj)
        {
            return this.tombo == ((Exemplar)obj).tombo;
        }
    }
}
