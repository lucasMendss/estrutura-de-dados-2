using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_gerenciador_de_projetos
{
    internal class Program
    {
        private static Projetos projetos = new Projetos();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar projeto");
                Console.WriteLine("2. Pesquisar projeto");
                Console.WriteLine("3. Remover projeto");
                Console.WriteLine("4. Adicionar tarefa em projeto");
                Console.WriteLine("5. Concluir tarefa");
                Console.WriteLine("6. Cancelar tarefa");
                Console.WriteLine("7. Reabrir tarefa");
                Console.WriteLine("8. Listar tarefas de um projeto");
                Console.WriteLine("9. Filtrar tarefas por status ou prioridade em um projeto");
                Console.WriteLine("10. Filtrar tarefas por status ou prioridade em todos os projetos");
                Console.WriteLine("11. Resumo geral");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        return;
                    case "1":
                        AdicionarProjeto();
                        break;
                    case "2":
                        PesquisarProjeto();
                        break;
                    case "3":
                        RemoverProjeto();
                        break;
                    case "4":
                        AdicionarTarefa();
                        break;
                    case "5":
                        ConcluirTarefa();
                        break;
                    case "6":
                        CancelarTarefa();
                        break;
                    case "7":
                        ReabrirTarefa();
                        break;
                    case "8":
                        ListarTarefasProjeto();
                        break;
                    case "9":
                        FiltrarTarefasProjeto();
                        break;
                    case "10":
                        FiltrarTarefasTodosProjetos();
                        break;
                    case "11":
                        ResumoGeral();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private static void AdicionarProjeto()
        {
            Console.WriteLine("Digite o nome do projeto:");
            string nome = Console.ReadLine();
            Projeto p = new Projeto(nome);
            projetos.Adicionar(p);
            Console.WriteLine($"Projeto '{nome}' adicionado com sucesso.");
        }

        private static void PesquisarProjeto()
        {
            Console.WriteLine("Digite o nome do projeto para pesquisar:");
            string nome = Console.ReadLine();
            Projeto p = projetos.Itens.FirstOrDefault(proj => proj.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
            if (p != null)
            {
                Console.WriteLine($"Projeto encontrado: {p.Nome} (ID: {p.Id})");
                // todo: Mostrar tarefas por status e totais
                Console.WriteLine($"Tarefas abertas {p.TarefasPorStatus("Aberta").Count()}:");
                foreach (var tarefa in p.TarefasPorStatus("Aberta"))
                {
                    Console.WriteLine(tarefa.ToString());
                }

                Console.WriteLine($"Tarefas fechadas {p.TarefasPorStatus("Fechada").Count()}:");
                foreach (var tarefa in p.TarefasPorStatus("Fechada"))
                {
                    Console.WriteLine(tarefa.ToString());
                }

                Console.WriteLine($"Tarefas canceladas {p.TarefasPorStatus("Cancelada").Count()}:");
                foreach (var tarefa in p.TarefasPorStatus("Cancelada"))
                {
                    Console.WriteLine(tarefa.ToString());
                }
            }
            else
            {
                Console.WriteLine("Projeto não encontrado.");
            }
        }

        private static void RemoverProjeto()
        {
            Projeto p = ObterProjetoPorNome("Digite o nome do projeto para remover:");
            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            if (p.Tarefas.Count > 0)
            {
                Console.WriteLine("Não é possível remover um projeto que possua tarefas.");
                return;
            }

            if (projetos.Remover(p))
            {
                Console.WriteLine("Projeto removido com sucesso.");
            }
        }

        private static void AdicionarTarefa()
        {
            Projeto p = ObterProjetoPorNome("Digite o nome do projeto para adicionar a tarefa:");
            if (p != null)
            {
                Console.WriteLine("Digite o título da tarefa:");
                string titulo = Console.ReadLine();
                Console.WriteLine("Digite a descrição da tarefa:");
                string descricao = Console.ReadLine();
                Console.WriteLine("Digite a prioridade da tarefa (1-3):");
                int prioridade;
                while (!int.TryParse(Console.ReadLine(), out prioridade) || prioridade < 1 || prioridade > 3)
                {
                    Console.WriteLine("Prioridade inválida. Digite um número entre 1 e 3:");
                }

                Tarefa t = new Tarefa(titulo, descricao, prioridade);
                p.AdicionarTarefa(t);
                Console.WriteLine($"Tarefa '{titulo}' adicionada ao projeto '{p.Nome}' com sucesso.");
            }
            else
            {
                Console.WriteLine("Projeto não encontrado.");
            }
        }

        private static void ConcluirTarefa()
        {
            AlterarStatusTarefa("Fechada", tarefa => tarefa.Concluir());
        }

        private static void CancelarTarefa()
        {
            AlterarStatusTarefa("Cancelada", tarefa => tarefa.Cancelar());
        }

        private static void ReabrirTarefa()
        {
            AlterarStatusTarefa("Aberta", tarefa => tarefa.Reabrir());
        }

        private static void ListarTarefasProjeto()
        {
            Projeto p = ObterProjetoPorNome("Digite o nome do projeto para listar as tarefas:");
            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            Console.WriteLine($"Tarefas do projeto '{p.Nome}':");
            ExibirTarefas(p.Tarefas);
        }

        private static void FiltrarTarefasProjeto()
        {
            Projeto p = ObterProjetoPorNome("Digite o nome do projeto:");
            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            ExibirFiltroProjeto(p);
        }

        private static void FiltrarTarefasTodosProjetos()
        {
            Console.WriteLine("Filtrar por 1-Status ou 2-Prioridade?");
            string tipo = Console.ReadLine();

            if (tipo == "1")
            {
                Console.WriteLine("Digite o status (Aberta, Fechada ou Cancelada):");
                string status = Console.ReadLine();
                var tarefas = projetos.Itens
                    .SelectMany(projeto => projeto.Tarefas
                        .Where(tarefa => string.Equals(tarefa.Status, status, StringComparison.OrdinalIgnoreCase))
                        .Select(tarefa => Tuple.Create(projeto, tarefa)))
                    .ToList();

                ExibirResultadoFiltragem(tarefas);
            }
            else if (tipo == "2")
            {
                Console.WriteLine("Digite a prioridade (1-3):");
                int prioridade;
                while (!int.TryParse(Console.ReadLine(), out prioridade) || prioridade < 1 || prioridade > 3)
                {
                    Console.WriteLine("Prioridade inválida. Digite um número entre 1 e 3:");
                }

                var tarefas = projetos.Itens
                    .SelectMany(projeto => projeto.Tarefas
                        .Where(tarefa => tarefa.Prioridade == prioridade)
                        .Select(tarefa => Tuple.Create(projeto, tarefa)))
                    .ToList();

                ExibirResultadoFiltragem(tarefas);
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        private static void ResumoGeral()
        {
            var todasAsTarefas = projetos.Itens.SelectMany(projeto => projeto.Tarefas).ToList();
            int abertas = todasAsTarefas.Count(tarefa => string.Equals(tarefa.Status, "Aberta", StringComparison.OrdinalIgnoreCase));
            int fechadas = todasAsTarefas.Count(tarefa => string.Equals(tarefa.Status, "Fechada", StringComparison.OrdinalIgnoreCase));
            int canceladas = todasAsTarefas.Count(tarefa => string.Equals(tarefa.Status, "Cancelada", StringComparison.OrdinalIgnoreCase));
            double percentual = abertas == 0 ? 0 : (fechadas * 100.0 / abertas);

            Console.WriteLine($"Quantidade de projetos: {projetos.Itens.Count}");
            Console.WriteLine($"Tarefas abertas: {abertas}");
            Console.WriteLine($"Tarefas fechadas: {fechadas}");
            Console.WriteLine($"Tarefas canceladas: {canceladas}");
            Console.WriteLine($"% concluídas em relação às abertas: {percentual:0.##}%");
        }

        private static void AlterarStatusTarefa(string statusEsperado, Action<Tarefa> acao)
        {
            Projeto p = ObterProjetoPorNome("Digite o nome do projeto:");
            if (p == null)
            {
                Console.WriteLine("Projeto não encontrado.");
                return;
            }

            Tarefa tarefa = ObterTarefaPorId(p, "Digite o ID da tarefa:");
            if (tarefa == null)
            {
                Console.WriteLine("Tarefa não encontrada.");
                return;
            }

            acao(tarefa);
            Console.WriteLine($"Tarefa atualizada para o status '{statusEsperado}'.");
        }

        private static Projeto ObterProjetoPorNome()
        {
            return ObterProjetoPorNome("Digite o nome do projeto:");
        }

        private static Projeto ObterProjetoPorNome(string mensagem)
        {
            Console.WriteLine(mensagem);
            string nome = Console.ReadLine();
            return projetos.Itens.FirstOrDefault(proj => proj.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        private static Tarefa ObterTarefaPorId(Projeto projeto, string mensagem)
        {
            Console.WriteLine(mensagem);
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido. Digite um número inteiro:");
            }

            return projeto.Tarefas.FirstOrDefault(tarefa => tarefa.Id == id);
        }

        private static void ExibirTarefas(IEnumerable<Tarefa> tarefas)
        {
            if (!tarefas.Any())
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var tarefa in tarefas)
            {
                Console.WriteLine(tarefa);
            }
        }

        private static void ExibirFiltroProjeto(Projeto projeto)
        {
            Console.WriteLine("Filtrar por 1-Status ou 2-Prioridade?");
            string tipo = Console.ReadLine();

            if (tipo == "1")
            {
                Console.WriteLine("Digite o status (Aberta, Fechada ou Cancelada):");
                string status = Console.ReadLine();
                ExibirTarefas(projeto.TarefasPorStatus(status));
            }
            else if (tipo == "2")
            {
                Console.WriteLine("Digite a prioridade (1-3):");
                int prioridade;
                while (!int.TryParse(Console.ReadLine(), out prioridade) || prioridade < 1 || prioridade > 3)
                {
                    Console.WriteLine("Prioridade inválida. Digite um número entre 1 e 3:");
                }

                ExibirTarefas(projeto.TarefasPorPrioridade(prioridade));
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }

        private static void ExibirResultadoFiltragem(IEnumerable<Tuple<Projeto, Tarefa>> resultados)
        {
            if (!resultados.Any())
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
                return;
            }

            foreach (var item in resultados)
            {
                Console.WriteLine($"Projeto: {item.Item1.Nome} (ID: {item.Item1.Id})");
                Console.WriteLine(item.Item2);
            }
        }
    }
}
