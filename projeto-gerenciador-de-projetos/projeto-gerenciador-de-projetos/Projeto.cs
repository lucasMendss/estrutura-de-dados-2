using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_gerenciador_de_projetos
{
    public class Projeto
    {
        private static int proximoId = 1;
        private int id;
        private string nome;
        private List<Tarefa> tarefas;

        public int Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public List<Tarefa> Tarefas
        {
            get { return tarefas; }
        }

        public Projeto(string nome)
        {
            id = proximoId;
            proximoId++;
            tarefas = new List<Tarefa>();
            this.nome = nome;
        }

        public void AdicionarTarefa(Tarefa t)
        {
            if (t != null)
            {
                tarefas.Add(t);
            }
        }

        public bool RemoverTarefa(Tarefa t)
        {
            return tarefas.Remove(t);
        }

        public Tarefa BuscarTarefa(Tarefa t)
        {
            if (t == null)
            {
                return null;
            }

            return tarefas.FirstOrDefault(item => item.Id == t.Id);
        }

        public List<Tarefa> TarefasPorStatus(string s)
        {
            return tarefas.Where(tarefa => string.Equals(tarefa.Status, s, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Tarefa> TarefasPorPrioridade(int p)
        {
            return tarefas.Where(tarefa => tarefa.Prioridade == p).ToList();
        }

        public int TotalAbertas()
        {
            return tarefas.Count(tarefa => string.Equals(tarefa.Status, "Aberta", StringComparison.OrdinalIgnoreCase));
        }

        public int TotalFechadas()
        {
            return tarefas.Count(tarefa => string.Equals(tarefa.Status, "Fechada", StringComparison.OrdinalIgnoreCase));
        }
    }
}
