using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_medicamentos
{
    internal class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public List<Medicamento> ListaMedicamentos { get => listaMedicamentos; set => listaMedicamentos = value; }

        public Medicamentos()
        {
            this.listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            this.listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            Medicamento encontrado = this.Pesquisar(medicamento);
            if (encontrado.Id == 0 || encontrado.QtdeDisponivel() > 0)
            {
                return false;
            }

            return this.listaMedicamentos.Remove(encontrado);
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            foreach (Medicamento item in this.listaMedicamentos)
            {
                if (item.Equals(medicamento))
                {
                    return item;
                }
            }

            return new Medicamento(0, "", "");
        }
    }
}
