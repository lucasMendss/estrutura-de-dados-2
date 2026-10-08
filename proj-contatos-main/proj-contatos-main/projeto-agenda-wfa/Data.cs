using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_agenda_wfa
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public void setData(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}/{2}", dia, mes, ano);
        }

        public override bool Equals(object? obj)
        {
            return obj is Data data &&
                   dia == data.dia &&
                   mes == data.mes &&
                   ano == data.ano;
        }
    }
}
