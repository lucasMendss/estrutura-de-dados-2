using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projBiblioteca
{
    internal class Livro
    {
        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Editora { get => editora; set => editora = value; }
        internal List<Exemplar> Exemplares { get => exemplares; set => exemplares = value; }

        public Livro(int isbn, string titulo, string autor, string editora)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = new List<Exemplar>();
        }

        public Livro() : this(0, "", "", "")
        { }

        public Livro(int isbn) : this(isbn, "", "", "")
        { }

        public void adicionarExemplar(Exemplar exemplar)
        {
            this.exemplares.Add(exemplar);
        }

        public int qtdeExemplares()
        {
            return this.exemplares.Count;
        }

        public int qtdeDisponiveis()
        {
            int qtde = 0;
            foreach (Exemplar exemplar in this.exemplares)
            {
                if (exemplar.disponivel())
                {
                    qtde++;
                }
            }
            return qtde;
        }

        public int qtdeEmprestimos()
        {
            int qtde = 0;
            foreach (Exemplar exemplar in this.exemplares)
            {
                qtde += exemplar.qtdeEmprestimos();
            }
            return qtde;
        }

        public double percDisponibilidade()
        {
            if (qtdeExemplares() == 0)
            {
                return 0;
            }
            return (double)qtdeDisponiveis() / qtdeExemplares() * 100;
        }

        public override string ToString()
        {
            return "ISBN = " + this.isbn.ToString() + " | Título = " + this.titulo +
                   " | Autor = " + this.autor + " | Editora = " + this.editora;
        }

        public override bool Equals(object obj)
        {
            return this.isbn == ((Livro)obj).isbn;
        }
    }
}
