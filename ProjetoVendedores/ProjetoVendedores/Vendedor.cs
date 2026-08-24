using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendedores
{
    internal class Vendedor
    {
        private int id;
        private string nome;
        private double percentualComissao;
        private int qtdeVendas;
        private Venda[] listaVendas;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public double PercentualComissao { get => percentualComissao; set => percentualComissao = value; }
        public int QtdeVendas { get => qtdeVendas; set => qtdeVendas = value; }
        public Vendedor()
        {
            this.id = -1;
            this.nome = "-";
            this.percentualComissao = 0;
            this.listaVendas = new Venda[31];
            this.qtdeVendas = 0;
            for (int ii = 0; ii < 31; ii++)
            {
                listaVendas[ii] = new Venda();
            }
        }
        public Vendedor(int id, string nome, double percentual) : this()
        {
            this.id = id;
            this.nome = nome.ToUpper();
            this.percentualComissao = percentual;
        }
        public Vendedor(int id) : this()
        {
            this.id = id;
        }
        public void registrarVenda(int dia, Venda venda)
        {
            listaVendas[dia].Valor += venda.Valor;
            qtdeVendas++;
        }
        public double valorTotalVendas()
        {
            double valorVendas = 0;
            for(int ii = 0; ii < 31; ii++)
            {
                valorVendas += listaVendas[ii].Valor;   
            }
            return valorVendas;
        }
        public double valorComissao()
        {
            return valorTotalVendas() * (percentualComissao / 100);
        }
        public double valorMedioVendasDiarias()
        {
            double valorTotalVendas = this.valorTotalVendas();
            double qtdeDiasComVenda = 0;

            for (int ii = 0; ii < listaVendas.Length; ii++)
            {
                if (listaVendas[ii].Valor > 0)
                {
                    qtdeDiasComVenda++;
                }
            }

            if (qtdeDiasComVenda == 0)
            {
                return 0;
            }

            return valorTotalVendas / qtdeDiasComVenda;
        }
        public override string ToString()
        {
            return $"\nID: {id} | Nome: {nome} | Comissão: R${valorComissao().ToString("N2")} | " +
                $"Valor total de vendas: R${valorTotalVendas().ToString("N2")} | Valor médio de vendas diárias: " +
                $"R${valorMedioVendasDiarias().ToString("N2")} ";
        }
        public override bool Equals(object obj)
        {
            return obj is Vendedor vendedor &&
                   id == vendedor.id;
        }
    }
}
