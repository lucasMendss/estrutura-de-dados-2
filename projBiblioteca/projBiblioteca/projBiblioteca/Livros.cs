using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projBiblioteca
{
    internal class Livros
    {
        private List<Livro> acervo;

        internal List<Livro> Acervo { get => acervo; set => acervo = value; }

        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        public void adicionar(Livro livro)
        {
            this.acervo.Add(livro);
        }

        // Retorna o livro do acervo com o mesmo ISBN ou null se não existir
        public Livro pesquisar(Livro livro)
        {
            int pos = this.acervo.IndexOf(livro);
            if (pos == -1)
            {
                return null;
            }
            return this.acervo[pos];
        }
    }
}
