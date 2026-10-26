using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_medicamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Medicamentos medicamentos = new Medicamentos();
            while (true)
            {
                Console.WriteLine("\n0. Finalizar processo");
                Console.WriteLine("1. Cadastrar medicamento");
                Console.WriteLine("2. Consultar medicamento (sintético)");
                Console.WriteLine("3. Consultar medicamento (analítico)");
                Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
                Console.WriteLine("5. Vender medicamento");
                Console.WriteLine("6. Listar medicamentos");
                Console.Write("Opção: ");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida.");
                    continue;
                }

                if (opcao == 0)
                {
                    break;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("ID do medicamento: ");
                        int idCadastro;
                        if (!int.TryParse(Console.ReadLine(), out idCadastro) || idCadastro <= 0)
                        {
                            Console.WriteLine("ID inválido.");
                            break;
                        }
                        if (BuscarPorId(medicamentos, idCadastro) != null)
                        {
                            Console.WriteLine("Já existe medicamento com esse ID.");
                            break;
                        }

                        Console.Write("Nome do medicamento: ");
                        string nome = Console.ReadLine();
                        Console.Write("Laboratório: ");
                        string laboratorio = Console.ReadLine();
                        Medicamento novo = new Medicamento(idCadastro, nome, laboratorio);
                        medicamentos.Adicionar(novo);
                        Console.WriteLine("Cadastrado: " + novo);
                        break;

                    case 2:
                        Medicamento medSint = BuscarPorId(medicamentos);
                        if (medSint == null)
                        {
                            Console.WriteLine("Medicamento não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine(FormatarMedicamento(medSint));
                        }
                        break;

                    case 3:
                        Medicamento medAnal = BuscarPorId(medicamentos);
                        if (medAnal == null)
                        {
                            Console.WriteLine("Medicamento não encontrado.");
                        }
                        else
                        {
                            Console.WriteLine(FormatarMedicamento(medAnal));
                            foreach (Lote lote in medAnal.Lotes)
                            {
                                Console.WriteLine(FormatarLote(lote));
                            }
                        }
                        break;

                    case 4:
                        Medicamento medCompra = BuscarPorId(medicamentos);
                        if (medCompra == null)
                        {
                            Console.WriteLine("Medicamento não encontrado.");
                        }
                        else
                        {
                            Console.Write("ID do lote: ");
                            int idLote;
                            if (!int.TryParse(Console.ReadLine(), out idLote) || idLote <= 0)
                            {
                                Console.WriteLine("ID inválido.");
                                break;
                            }

                            Console.Write("Quantidade do lote: ");
                            int qtdeCompra;
                            if (!int.TryParse(Console.ReadLine(), out qtdeCompra) || qtdeCompra <= 0)
                            {
                                Console.WriteLine("Quantidade inválida.");
                                break;
                            }

                            Console.Write("Data de vencimento (dd/MM/yyyy): ");
                            DateTime venc;
                            if (!DateTime.TryParse(Console.ReadLine(), out venc))
                            {
                                Console.WriteLine("Data inválida.");
                                break;
                            }

                            medCompra.Comprar(new Lote(idLote, qtdeCompra, venc));
                            Console.WriteLine("Compra registrada.");
                        }
                        break;

                    case 5:
                        Medicamento medVenda = BuscarPorId(medicamentos);
                        if (medVenda == null)
                        {
                            Console.WriteLine("Medicamento não encontrado.");
                        }
                        else
                        {
                            Console.Write("Quantidade para venda: ");
                            int qtdeVenda;
                            if (!int.TryParse(Console.ReadLine(), out qtdeVenda) || qtdeVenda <= 0)
                            {
                                Console.WriteLine("Quantidade inválida.");
                                break;
                            }

                            bool vendeu = medVenda.Vender(qtdeVenda);
                            Console.WriteLine(vendeu ? "Venda realizada." : "Saldo insuficiente.");
                        }
                        break;

                    case 6:
                        if (medicamentos.ListaMedicamentos.Count == 0)
                        {
                            Console.WriteLine("Nenhum medicamento cadastrado.");
                        }
                        else
                        {
                            foreach (Medicamento med in medicamentos.ListaMedicamentos)
                            {
                                Console.WriteLine(FormatarMedicamento(med));
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static Medicamento BuscarPorId(Medicamentos medicamentos)
        {
            Console.Write("ID do medicamento: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                return null;
            }

            return BuscarPorId(medicamentos, id);
        }

        static Medicamento BuscarPorId(Medicamentos medicamentos, int id)
        {
            foreach (Medicamento med in medicamentos.ListaMedicamentos)
            {
                if (med.Id == id)
                {
                    return med;
                }
            }

            return null;
        }

        static string FormatarMedicamento(Medicamento medicamento)
        {
            return "id: " + medicamento.Id
                + " | nome: " + medicamento.Nome
                + " | laboratorio: " + medicamento.Laboratorio
                + " | quantidadeDisponivel: " + medicamento.QtdeDisponivel();
        }

        static string FormatarLote(Lote lote)
        {
            return "idLote: " + lote.Id
                + " | quantidade: " + lote.Qtde
                + " | vencimento: " + lote.Venc.ToString("dd/MM/yyyy");
        }
    }
}
