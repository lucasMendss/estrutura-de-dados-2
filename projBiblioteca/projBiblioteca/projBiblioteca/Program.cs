using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projBiblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livros livros = new Livros();
            int opcao;

            do
            {
                opcao = menu();
                Console.WriteLine();
                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Encerrando...");
                        break;
                    case 1:
                        adicionarLivro(livros);
                        break;
                    case 2:
                        pesquisarLivro(livros, false);
                        break;
                    case 3:
                        pesquisarLivro(livros, true);
                        break;
                    case 4:
                        adicionarExemplar(livros);
                        break;
                    case 5:
                        registrarEmprestimo(livros);
                        break;
                    case 6:
                        registrarDevolucao(livros);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }

        static int menu()
        {
            Console.WriteLine();
            Console.WriteLine("===== BIBLIOTECA =====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar livro");
            Console.WriteLine("2. Pesquisar livro (sintético)");
            Console.WriteLine("3. Pesquisar livro (analítico)");
            Console.WriteLine("4. Adicionar exemplar");
            Console.WriteLine("5. Registrar empréstimo");
            Console.WriteLine("6. Registrar devolução");
            return lerInteiro("Opção: ");
        }

        static int lerInteiro(string mensagem)
        {
            int valor;
            Console.Write(mensagem);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Valor inválido. " + mensagem);
            }
            return valor;
        }

        static string lerTexto(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine();
        }

        // Pede o ISBN e devolve o livro do acervo (ou null, já informando o usuário)
        static Livro localizarLivro(Livros livros)
        {
            int isbn = lerInteiro("ISBN: ");
            Livro livro = livros.pesquisar(new Livro(isbn));
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado!");
            }
            return livro;
        }

        // O tombo identifica o exemplar em toda a biblioteca
        static bool tomboExiste(Livros livros, int tombo)
        {
            foreach (Livro livro in livros.Acervo)
            {
                if (livro.Exemplares.IndexOf(new Exemplar(tombo)) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        static void adicionarLivro(Livros livros)
        {
            int isbn = lerInteiro("ISBN: ");
            if (livros.pesquisar(new Livro(isbn)) != null)
            {
                Console.WriteLine("Já existe um livro com esse ISBN!");
                return;
            }
            string titulo = lerTexto("Título: ");
            string autor = lerTexto("Autor: ");
            string editora = lerTexto("Editora: ");

            livros.adicionar(new Livro(isbn, titulo, autor, editora));
            Console.WriteLine("Livro adicionado!");
        }

        static void pesquisarLivro(Livros livros, bool analitico)
        {
            Livro livro = localizarLivro(livros);
            if (livro == null)
            {
                return;
            }

            Console.WriteLine(livro.ToString());
            Console.WriteLine("Total de exemplares: {0}", livro.qtdeExemplares());
            Console.WriteLine("Exemplares disponíveis: {0}", livro.qtdeDisponiveis());
            Console.WriteLine("Total de empréstimos: {0}", livro.qtdeEmprestimos());
            Console.WriteLine("Disponibilidade: {0:F2}%", livro.percDisponibilidade());

            if (analitico)
            {
                foreach (Exemplar exemplar in livro.Exemplares)
                {
                    Console.WriteLine("  " + exemplar.ToString());
                    foreach (Emprestimo emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine("    " + emprestimo.ToString());
                    }
                }
            }
        }

        static void adicionarExemplar(Livros livros)
        {
            Livro livro = localizarLivro(livros);
            if (livro == null)
            {
                return;
            }
            int tombo = lerInteiro("Tombo: ");
            if (tomboExiste(livros, tombo))
            {
                Console.WriteLine("Já existe um exemplar com esse tombo!");
                return;
            }
            livro.adicionarExemplar(new Exemplar(tombo));
            Console.WriteLine("Exemplar adicionado!");
        }

        static Exemplar localizarExemplar(Livros livros)
        {
            Livro livro = localizarLivro(livros);
            if (livro == null)
            {
                return null;
            }
            int tombo = lerInteiro("Tombo: ");
            int pos = livro.Exemplares.IndexOf(new Exemplar(tombo));
            if (pos == -1)
            {
                Console.WriteLine("Exemplar não encontrado!");
                return null;
            }
            return livro.Exemplares[pos];
        }

        static void registrarEmprestimo(Livros livros)
        {
            Exemplar exemplar = localizarExemplar(livros);
            if (exemplar == null)
            {
                return;
            }
            Console.WriteLine(exemplar.emprestar() ? "Empréstimo registrado!" : "Exemplar indisponível!");
        }

        static void registrarDevolucao(Livros livros)
        {
            Exemplar exemplar = localizarExemplar(livros);
            if (exemplar == null)
            {
                return;
            }
            Console.WriteLine(exemplar.devolver() ? "Devolução registrada!" : "Exemplar não está emprestado!");
        }
    }
}
