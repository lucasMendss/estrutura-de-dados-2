using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoVendedores
{
    internal class Vendedores
    {
        private Vendedor[] listaVendedores = new Vendedor[Max];
        private static int max = 10;
        private int qtde;

        public static int Max { get => max; }
        public int Qtde { get => qtde; set => qtde = value; }
        internal Vendedor[] ListaVendedores { get => listaVendedores; }

        public Vendedores()
        {
            for(int ii = 0; ii < max; ii++)
            {
                listaVendedores[ii] = new Vendedor();
            }
        }
        public bool addVendedor(Vendedor v)
        {
            if (qtde < max)
            {
                // adiciona na primeira posição vazia (id = -1
                for(int ii = 0; ii < max; ii++)
                {
                    if (listaVendedores[ii].Id == -1)
                    {
                        ListaVendedores[qtde++] = v;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool delVendedor(Vendedor v)
        {
            if(v.QtdeVendas == 0)
            {
                for(int ii = 0; ii < max; ii++)
                {
                    if(listaVendedores[ii] == v)
                    {
                        listaVendedores[ii] = new Vendedor();
                        qtde--;
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public Vendedor searchVendedor(Vendedor v)
        {
            Vendedor achado = new Vendedor();

            int ii = 0;
            while (ii < max && this.listaVendedores[ii].Id != v.Id)
            {
                ++ii;
            }
            if (ii < max)
            {
                achado = this.listaVendedores[ii];
            }
            return achado;
        }
        public double valorTotalVendas()
        {
            double valorTotalVendas = 0;
            for (int ii = 0; ii < max; ii++)
            {
                valorTotalVendas += listaVendedores[ii].valorTotalVendas();
            }
            return valorTotalVendas;
        }
        public double valorTotalComissoes()
        {
            double valorTotalComissoes = 0;
            for (int ii = 0; ii < max; ii++)
            {
                valorTotalComissoes += listaVendedores[ii].valorComissao();
            }
            return valorTotalComissoes;
        }
    }
}
