using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendedores
{
    internal class Program
    {
        // Models: Venda, Vendedor
        // View: Program.cs
        // Controllers: Vendedores (controller de Vendedor), Vendedor (controller de Venda)
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores();

            Console.WriteLine("====== Gerenciamento de vendedores ======");

            bool programaFinalizado = false;
            int opcao;
            int idAtual = 1;
            while (!programaFinalizado)
            {
                Console.WriteLine("\n--- MENU DE OPÇÕES ---");
                Console.WriteLine("- 0: Sair");
                Console.WriteLine("- 1: Cadastrar vendedor");
                Console.WriteLine("- 2: Consultar vendedor");
                Console.WriteLine("- 3: Excluir vendedor");
                Console.WriteLine("- 4: Registrar venda");
                Console.WriteLine("- 5: Listar vendedores");
                Console.WriteLine("----------------------");

                Console.Write("\nDigite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Console.Write("Finalizando sistema...");
                        programaFinalizado = true;
                        break;
                    case 1:
                        {
                            // se houver espaço na lista, adicionar novo vendedor
                            if (vendedores.Qtde < Vendedores.Max)
                            {
                                Console.Write("Digite o nome do vendedor: ");
                                string nome = Console.ReadLine();

                                Console.Write("Digite a % de comissão: ");
                                double percentual = double.Parse(Console.ReadLine());

                                Vendedor v = new Vendedor(idAtual, nome, percentual);
                                vendedores.addVendedor(v);

                                Console.WriteLine("Vendedor cadastrado com sucesso.");
                                idAtual++;
                                break;
                            }
                            Console.WriteLine("Não há espaço para novos vendedores.");
                            break;
                        }
                    case 2:
                        {
                            // buscar vendedor por ID e mostrar info caso encontrado
                            Console.Write("\nDigite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());

                            Vendedor v = new Vendedor(id);
                            Vendedor achado = vendedores.searchVendedor(v);
                            if (achado.Id != -1)
                            {
                                Console.WriteLine("Encontrado:\n" + achado.ToString());
                                break;
                            }
                            Console.WriteLine($"\nVendedor com ID {id} não encontrado.");
                            break;
                        }
                    case 3:
                        {
                            // buscar vendedor por ID antes de excluí-lo
                            Console.Write("\nDigite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());

                            Vendedor v = vendedores.searchVendedor(new Vendedor(id));

                            // se o vendedor for encontrado
                            if (vendedores.searchVendedor(v).Id != -1)
                            {
                                // e se o vendedor for excluído
                                if (vendedores.delVendedor(v))
                                {
                                    Console.WriteLine("Vendedor excluído com sucesso.");
                                    break;
                                }
                                Console.WriteLine("Impossível excluir vendedor que possui registro de vendas.");
                                break;
                            }
                            Console.WriteLine($"\nVendedor com ID {id} não encontrado.");
                            break;
                        }
                    case 4:
                        {
                            // cadastrar uma venda vinculando-a a um vendedor
                            Console.Write("\nDigite o dia da venda: ");
                            int dia = int.Parse(Console.ReadLine());

                            Console.Write("\nDigite a quantidade de produtos vendidos: ");
                            int qtde = int.Parse(Console.ReadLine());

                            Console.Write("\nDigite o valor (R$) da venda: ");
                            double valor = double.Parse(Console.ReadLine());

                            Venda venda = new Venda(qtde, valor);

                            Console.Write("\nDigite o ID do vendedor: ");
                            int id = int.Parse(Console.ReadLine());

                            bool vendaCadastrada = false;
                            for (int ii = 0; ii < vendedores.Qtde; ii++)
                            {
                                if (vendedores.ListaVendedores[ii].Id == id)
                                {
                                    vendedores.ListaVendedores[ii].registrarVenda(dia, venda);
                                    Console.WriteLine("Venda cadastrada com sucesso.");
                                    vendaCadastrada = true;
                                    break;
                                }
                            }
                            if (!vendaCadastrada)
                            {
                                Console.WriteLine($"\nVendedor com ID {id} não encontrado.");
                                break;
                            }
                            break;
                        }
                    case 5:
                        {
                            // listar vendedores e exibir informações
                            Console.WriteLine("\nVendedores:");
                            for (int ii = 0; ii < vendedores.Qtde; ii++)
                            {
                                Console.WriteLine(vendedores.ListaVendedores[ii].ToString());
                            }
                            Console.WriteLine("----------------------------------------------");
                            Console.WriteLine($"Ganhos totais: R${vendedores.valorTotalVendas().ToString("N2")} | Total em comissões: " +
                                $"R${vendedores.valorTotalComissoes().ToString("N2")}");
                            break;
                        }
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
