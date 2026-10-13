using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAgenda
{
    internal class Contato
    {
        private string email;
        private string nome;
        private Data dtNasc;
        private List<Telefone> telefones;

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Data DtNasc { get => dtNasc; set => dtNasc = value; }
        internal List<Telefone> Telefones { get => telefones; set => telefones = value; }

        public Contato(string email, string nome, Data dtNasc)
        {
            this.email = email;
            this.nome = nome;
            this.dtNasc = dtNasc;
            this.telefones = new List<Telefone>();
        }

        public Contato() : this("", "", new Data())
        { }

        public Contato(string email) : this(email, "", new Data())
        { }

        public int getIdade()
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - this.dtNasc.Ano;
            // ainda não fez aniversário neste ano
            if (hoje.Month < this.dtNasc.Mes || (hoje.Month == this.dtNasc.Mes && hoje.Day < this.dtNasc.Dia))
            {
                idade--;
            }
            return idade;
        }

        public void adicionarTelefone(Telefone t)
        {
            // o primeiro telefone é sempre o principal e só pode haver um principal
            if (this.telefones.Count == 0)
            {
                t.Principal = true;
            }
            else if (t.Principal)
            {
                foreach (Telefone outro in this.telefones)
                {
                    outro.Principal = false;
                }
            }
            this.telefones.Add(t);
        }

        public string getTelefonePrincipal()
        {
            foreach (Telefone t in this.telefones)
            {
                if (t.Principal)
                {
                    return t.Numero;
                }
            }
            return "";
        }

        public override string ToString()
        {
            return "Nome: " + this.nome +
                   " | E-mail: " + this.email +
                   " | Nascimento: " + this.dtNasc.ToString() +
                   " | Idade: " + getIdade().ToString() +
                   " | Telefone principal: " + getTelefonePrincipal();
        }

        public override bool Equals(object obj)
        {
            return this.email == ((Contato)obj).email;
        }
    }
}
