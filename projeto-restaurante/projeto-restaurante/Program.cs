using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_restaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao sistema de pedidos do restaurante!");

            while (true)
            { 
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Novo pedido");
                Console.WriteLine("2 - Adicionar item a pedido");
                Console.WriteLine("3 - Remover item de pedido");
                Console.WriteLine("4 - Consultar pedido");
                Console.WriteLine("5 - Cancelar pedido");
                Console.WriteLine("6 - Listar todos os pedidos");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "0":
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    case "1":
                        // Novo pedido
                        Console.Write("Nome do cliente: ");
                        var cliente = Console.ReadLine();
                        var novo = new Pedido(cliente ?? string.Empty);
                        if (Restaurante.novoPedido(novo))
                            Console.WriteLine($"Pedido criado com Id {novo.Id} para {novo.Cliente}.");
                        else
                            Console.WriteLine("Não foi possível criar o pedido (capacidade cheia).");
                        break;
                    case "2":
                        // Adicionar item a pedido
                        Console.Write("Id do pedido: ");
                        if (!int.TryParse(Console.ReadLine(), out int idAdd)) { Console.WriteLine("Id inválido."); break; }
                        var buscAdd = new Pedido("") { Id = idAdd };
                        var pedidoAdd = Restaurante.buscarPedido(buscAdd);
                        if (pedidoAdd == null) { Console.WriteLine("Pedido não encontrado."); break; }
                        Console.Write("Descrição do item: ");
                        var desc = Console.ReadLine();
                        Console.Write("Preço do item: ");
                        if (!double.TryParse(Console.ReadLine(), out double precoAdd)) { Console.WriteLine("Preço inválido."); break; }
                        var item = new Item(desc ?? string.Empty, precoAdd);
                        if (pedidoAdd.adicionarItem(item))
                            Console.WriteLine($"Item adicionado (Id interno {item.Id}).");
                        else
                            Console.WriteLine("Não foi possível adicionar o item (pedido cheio).");
                        break;
                    case "3":
                        // Remover item de pedido
                        Console.Write("Id do pedido: ");
                        if (!int.TryParse(Console.ReadLine(), out int idRem)) { Console.WriteLine("Id inválido."); break; }
                        var buscRem = new Pedido("") { Id = idRem };
                        var pedidoRem = Restaurante.buscarPedido(buscRem);
                        if (pedidoRem == null) { Console.WriteLine("Pedido não encontrado."); break; }
                        Console.WriteLine("Itens do pedido:");
                        foreach (var it in pedidoRem.Itens)
                        {
                            if (it != null) Console.WriteLine($" - Id {it.Id}: {it.Descricao} (R$ {it.Preco:F2})");
                        }
                        Console.Write("Id do item a remover: ");
                        if (!int.TryParse(Console.ReadLine(), out int idItemRem)) { Console.WriteLine("Id inválido."); break; }
                        var tempItem = new Item() { Id = idItemRem };
                        if (pedidoRem.removerItem(tempItem))
                            Console.WriteLine("Item removido com sucesso.");
                        else
                            Console.WriteLine("Item não encontrado no pedido.");
                        break;
                    case "4":
                        // Consultar pedido
                        Console.Write("Id do pedido: ");
                        if (!int.TryParse(Console.ReadLine(), out int idCons)) { Console.WriteLine("Id inválido."); break; }
                        var buscCons = new Pedido("") { Id = idCons };
                        var pedidoCons = Restaurante.buscarPedido(buscCons);
                        if (pedidoCons == null) { Console.WriteLine("Pedido não encontrado."); break; }
                        Console.WriteLine(pedidoCons.dadosDoPedido());
                        break;
                    case "5":
                        // Cancelar pedido
                        Console.Write("Id do pedido: ");
                        if (!int.TryParse(Console.ReadLine(), out int idCan)) { Console.WriteLine("Id inválido."); break; }
                        var buscCan = new Pedido("") { Id = idCan };
                        var pedidoCan = Restaurante.buscarPedido(buscCan);
                        if (pedidoCan == null) { Console.WriteLine("Pedido não encontrado."); break; }
                        if (Restaurante.cancelarPedido(pedidoCan))
                            Console.WriteLine("Pedido cancelado com sucesso.");
                        else
                            Console.WriteLine("Falha ao cancelar pedido.");
                        break;
                    case "6":
                        // Listar todos os pedidos
                        double somaGeral = 0.0;
                        Console.WriteLine("Pedidos ativos:");
                        foreach (var p in Restaurante.Pedidos)
                        {
                            if (p == null) continue;
                            double total = p.calcularTotal();
                            somaGeral += total;
                            Console.WriteLine($" - Id {p.Id}: Cliente {p.Cliente} - Total R$ {total:F2}");
                        }
                        Console.WriteLine($"Soma geral do dia: R$ {somaGeral:F2}");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                
            }
        }
    }
}
