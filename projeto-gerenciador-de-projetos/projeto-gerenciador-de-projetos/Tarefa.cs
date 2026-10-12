using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_gerenciador_de_projetos
{
    public class Tarefa
    {
        private static int proximoId = 1;
        private int id;
        private string titulo;
        private string descricao;
        private int prioridade;
        private string status;
        private DateTime dataCriacao;
        private DateTime dataConclusao;

        public int Id
        {
            get { return id; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public int Prioridade
        {
            get { return prioridade; }
            set { prioridade = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime DataCriacao
        {
            get { return dataCriacao; }
        }

        public DateTime DataConclusao
        {
            get { return dataConclusao; }
            set { dataConclusao = value; }
        }

        public Tarefa(string titulo, string descricao, int prioridade)
        {
            id = proximoId;
            proximoId++;
            dataCriacao = DateTime.Now;
            dataConclusao = DateTime.MinValue;
            status = "Aberta";
            this.titulo = titulo;
            this.descricao = descricao;
            this.prioridade = prioridade;
        }

        public void Concluir()
        {
            status = "Fechada";
            dataConclusao = DateTime.Now;
        }

        public void Cancelar()
        {
            status = "Cancelada";
            dataConclusao = DateTime.Now;
        }

        public void Reabrir()
        {
            status = "Aberta";
            dataConclusao = DateTime.MinValue;
        }

        public override string ToString()
        {
              return $"ID: {id}, Título: {titulo}, Descrição: {descricao}, Prioridade: {prioridade}, Status: {status}, Data de Criação: {dataCriacao}, Data de Conclusão: {(dataConclusao == DateTime.MinValue ? "N/A" : dataConclusao.ToString())}";
        }
    }
}
