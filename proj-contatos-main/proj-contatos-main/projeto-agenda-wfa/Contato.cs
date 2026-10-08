using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda_wfa
{
    internal class Contato
    {
        private static int nextId = 1;
        private int id;
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones = new List<Telefone>();

        public int Id { get => id; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        internal Data DtNasc { get => dtNasc; set => dtNasc = value; }

        public Contato()
        {
        }

        public Contato(string email, string nome, Data dtNasc)
        {
            this.id = nextId++;
            this.Email = email;
            this.Nome = nome;
            this.DtNasc = dtNasc;
        }

        public void Atualizar(string email, string nome, Data dtNasc, string telefonePrincipal)
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
            telefones.Clear();
            adicionarTelefone(new Telefone("celular", telefonePrincipal, true));
        }

        public void adicionarTelefone(Telefone t)
        {
            telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            return telefones.FirstOrDefault(t => t.IsPrincipal())?.ToString() ?? string.Empty;
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} | Email: {1} | Data de Nascimento: {2} | Telefone Principal: {3}", Nome, Email, DtNasc.ToString(), getTelefonePrincipal());
        }

        public override bool Equals(object? obj)
        {
            return obj is Contato contato &&
                   Id == contato.Id &&
                   Email == contato.Email &&
                   Nome == contato.Nome &&
                   EqualityComparer<Data>.Default.Equals(DtNasc, contato.DtNasc) &&
                   EqualityComparer<List<Telefone>>.Default.Equals(telefones, contato.telefones);
        }
    }
}
