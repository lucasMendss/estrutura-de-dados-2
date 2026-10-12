using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_gerenciador_de_projetos
{
    public class Projetos
    {
        private List<Projeto> itens;

        public List<Projeto> Itens
        {
            get { return itens; }
            set { itens = value; }
        }

        public Projetos()
        {
            itens = new List<Projeto>();
        }

        public bool Adicionar(Projeto p)
        {
            if (p == null)
            {
                return false;
            }

            itens.Add(p);
            return true;
        }

        public bool Remover(Projeto p)
        {
            return itens.Remove(p);
        }

        public Projeto Buscar(Projeto p)
        {
            if (p == null)
            {
                return null;
            }

            return itens.FirstOrDefault(item => item.Id == p.Id);
        }

        public List<Projeto> Listar()
        {
            return new List<Projeto>(itens);
        }
    }
}
