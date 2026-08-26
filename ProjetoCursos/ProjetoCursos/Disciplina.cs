using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Disciplina
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public Curso Curso { get; private set; }
        public Aluno[] Alunos { get; private set; }
        public int QtdAlunos { get; private set; }

        public Disciplina(int id, string descricao, Curso curso)
        {
            Id = id;
            Descricao = descricao;
            Curso = curso;
            Alunos = new Aluno[15];
            QtdAlunos = 0;
        }

        public bool matricularAluno(Aluno aluno)
        {
            // Limite máximo de 15 alunos por disciplina.
            if (QtdAlunos >= 15) return false;
            // Não permite matrícula duplicada.
            for (int i = 0; i < QtdAlunos; i++)
            {
                if (Alunos[i] != null && Alunos[i].Id == aluno.Id)
                    return false;
            }
            // Respeita a regra "cada aluno só pode estar matriculado em um único curso".
            if (aluno.Curso == null || aluno.Curso.Id != Curso.Id) return false;
            // Respeita a regra "no máximo 6 disciplinas simultâneas".
            if (!aluno.podeMatricular(this)) return false;

            Alunos[QtdAlunos++] = aluno;
            aluno.adicionarDisciplina(this);
            return true;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < QtdAlunos; i++)
            {
                if (Alunos[i] != null && Alunos[i].Id == aluno.Id)
                {
                    for (int j = i; j < QtdAlunos - 1; j++)
                        Alunos[j] = Alunos[j + 1];
                    Alunos[QtdAlunos - 1] = null;
                    QtdAlunos--;
                    aluno.removerDisciplina(this);
                    return true;
                }
            }
            return false;
        }
    }
}
