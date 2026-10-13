using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAgenda
{
    internal class Contatos
    {
        private readonly List<Contato> agenda;

        internal List<Contato> Agenda { get => agenda; }

        public Contatos()
        {
            this.agenda = new List<Contato>();
        }

        public bool adicionar(Contato c)
        {
            if (this.agenda.IndexOf(c) != -1)
            {
                return false;
            }
            this.agenda.Add(c);
            return true;
        }

        // Retorna o contato da agenda com o mesmo e-mail ou null se não existir
        public Contato pesquisar(Contato c)
        {
            int pos = this.agenda.IndexOf(c);
            if (pos == -1)
            {
                return null;
            }
            return this.agenda[pos];
        }

        // Substitui os dados do contato que possui o mesmo e-mail
        public bool alterar(Contato c)
        {
            int pos = this.agenda.IndexOf(c);
            if (pos == -1)
            {
                return false;
            }
            this.agenda[pos] = c;
            return true;
        }

        public bool remover(Contato c)
        {
            return this.agenda.Remove(c);
        }
    }
}
