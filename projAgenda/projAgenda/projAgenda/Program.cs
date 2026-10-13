using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAgenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contatos contatos = new Contatos();
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
                        adicionarContato(contatos);
                        break;
                    case 2:
                        pesquisarContato(contatos);
                        break;
                    case 3:
                        alterarContato(contatos);
                        break;
                    case 4:
                        removerContato(contatos);
                        break;
                    case 5:
                        listarContatos(contatos);
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
            Console.WriteLine("===== AGENDA =====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Pesquisar contato");
            Console.WriteLine("3. Alterar contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Listar contatos");
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

        static bool lerSimNao(string mensagem)
        {
            return lerTexto(mensagem + " (S/N): ").Trim().ToUpper() == "S";
        }

        static Data lerData(string mensagem)
        {
            Data data = new Data();
            do
            {
                Console.WriteLine(mensagem);
                data.setData(lerInteiro("  Dia: "), lerInteiro("  Mês: "), lerInteiro("  Ano: "));
                if (!data.valida())
                {
                    Console.WriteLine("Data inválida!");
                }
            } while (!data.valida());
            return data;
        }

        // Lê nome, data de nascimento e telefones de um contato já identificado pelo e-mail
        static Contato lerContato(string email)
        {
            string nome = lerTexto("Nome: ");
            Data dtNasc = lerData("Data de nascimento:");
            Contato contato = new Contato(email, nome, dtNasc);

            while (lerSimNao("Adicionar telefone?"))
            {
                string tipo = lerTexto("Tipo (ex.: celular, residencial): ");
                string numero = lerTexto("Número: ");
                bool principal = lerSimNao("É o telefone principal?");
                contato.adicionarTelefone(new Telefone(tipo, numero, principal));
            }
            return contato;
        }

        static void mostraContato(Contato contato)
        {
            Console.WriteLine(contato.ToString());
            foreach (Telefone telefone in contato.Telefones)
            {
                Console.WriteLine("    " + telefone.ToString());
            }
        }

        static void adicionarContato(Contatos contatos)
        {
            string email = lerTexto("E-mail: ");
            if (contatos.pesquisar(new Contato(email)) != null)
            {
                Console.WriteLine("Já existe um contato com esse e-mail!");
                return;
            }
            Console.WriteLine(contatos.adicionar(lerContato(email)) ? "Contato adicionado!" : "Contato não adicionado!");
        }

        static void pesquisarContato(Contatos contatos)
        {
            Contato contato = contatos.pesquisar(new Contato(lerTexto("E-mail: ")));
            if (contato == null)
            {
                Console.WriteLine("Contato não encontrado!");
                return;
            }
            mostraContato(contato);
        }

        static void alterarContato(Contatos contatos)
        {
            string email = lerTexto("E-mail do contato a alterar: ");
            Contato atual = contatos.pesquisar(new Contato(email));
            if (atual == null)
            {
                Console.WriteLine("Contato não encontrado!");
                return;
            }
            mostraContato(atual);
            Console.WriteLine("Informe os novos dados (os telefones serão informados novamente):");
            Console.WriteLine(contatos.alterar(lerContato(email)) ? "Contato alterado!" : "Contato não alterado!");
        }

        static void removerContato(Contatos contatos)
        {
            Console.WriteLine(contatos.remover(new Contato(lerTexto("E-mail: "))) ? "Contato removido!" : "Contato não encontrado!");
        }

        static void listarContatos(Contatos contatos)
        {
            Console.WriteLine("=== Qtde: {0} ===", contatos.Agenda.Count);
            foreach (Contato contato in contatos.Agenda)
            {
                mostraContato(contato);
            }
        }
    }
}
