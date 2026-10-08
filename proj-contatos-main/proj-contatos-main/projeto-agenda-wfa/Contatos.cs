using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda_wfa
{
    internal class Contatos
    {
        private List<Contato> agenda = new List<Contato>();

        internal List<Contato> Agenda { get => agenda; set => agenda = value; }

        public bool adicionar(Contato c)
        {
            agenda.Add(c);
            return true;
        }

        public Contato? buscarPorId(int id)
        {
            return agenda.FirstOrDefault(contato => contato.Id == id);
        }

        public bool alterarPorId(int id, string email, string nome, Data dtNasc, string telefonePrincipal)
        {
            Contato? contato = buscarPorId(id);
            if (contato is null)
            {
                return false;
            }

            contato.Atualizar(email, nome, dtNasc, telefonePrincipal);
            return true;
        }

        public Contato? pesquisar(string email, string nome, Data dtNasc, string telefonePrincipal)
        {
            return agenda.FirstOrDefault(contato =>
                contato.Email == email &&
                contato.Nome == nome &&
                EqualityComparer<Data>.Default.Equals(contato.DtNasc, dtNasc) &&
                contato.getTelefonePrincipal() == telefonePrincipal);
        }

        public bool removerPorId(int id)
        {
            Contato? contato = buscarPorId(id);
            if (contato is null)
            {
                return false;
            }

            agenda.Remove(contato);
            return true;
        }
    }
}
