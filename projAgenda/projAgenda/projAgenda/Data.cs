using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projAgenda
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public int Dia { get => dia; set => dia = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Ano { get => ano; set => ano = value; }

        public Data(int dia, int mes, int ano)
        {
            setData(dia, mes, ano);
        }

        public Data() : this(1, 1, 1900)
        { }

        public void setData(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        // Verifica se a data existe no calendário (e não está no futuro)
        public bool valida()
        {
            if (this.ano < 1 || this.ano > DateTime.Today.Year || this.mes < 1 || this.mes > 12)
            {
                return false;
            }
            if (this.dia < 1 || this.dia > DateTime.DaysInMonth(this.ano, this.mes))
            {
                return false;
            }
            return new DateTime(this.ano, this.mes, this.dia) <= DateTime.Today;
        }

        public override string ToString()
        {
            return this.dia.ToString("00") + "/" + this.mes.ToString("00") + "/" + this.ano.ToString("0000");
        }
    }
}
