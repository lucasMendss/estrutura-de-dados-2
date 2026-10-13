using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projBiblioteca
{
    internal class Emprestimo
    {
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        public DateTime DtEmprestimo { get => dtEmprestimo; set => dtEmprestimo = value; }
        public DateTime DtDevolucao { get => dtDevolucao; set => dtDevolucao = value; }

        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            this.dtEmprestimo = dtEmprestimo;
            this.dtDevolucao = dtDevolucao;
        }

        // DateTime.MinValue indica que o empréstimo ainda não foi devolvido
        public Emprestimo() : this(DateTime.Now, DateTime.MinValue)
        { }

        public bool Devolvido()
        {
            return this.dtDevolucao != DateTime.MinValue;
        }

        public override string ToString()
        {
            return "Empréstimo: " + this.dtEmprestimo.ToString("dd/MM/yyyy HH:mm") +
                   " | Devolução: " + (Devolvido() ? this.dtDevolucao.ToString("dd/MM/yyyy HH:mm") : "pendente");
        }
    }
}
