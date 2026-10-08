using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda_wfa
{
    internal class Telefone
    {
        private string tipo;
        private string numero;
        private bool principal;

        public Telefone(string tipo, string numero, bool principal)
        {
            this.tipo = tipo;
            this.numero = numero;
            this.principal = principal;
        }

        public bool IsPrincipal()
        {
            return principal;
        }

        public override string ToString()
        {
            return numero;
        }

        public override bool Equals(object? obj)
        {
            return obj is Telefone telefone &&
                   tipo == telefone.tipo &&
                   numero == telefone.numero &&
                   principal == telefone.principal;
        }
    }
}
