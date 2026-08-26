using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Aluno
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Curso Curso { get; private set; }
        public Disciplina[] Disciplinas { get; private set; }
        public int QtdDisciplinas { get; private set; }

        public Aluno(int id, string nome, Curso curso)
        {
            Id = id;
            Nome = nome;
            Curso = curso;
            Disciplinas = new Disciplina[6];
            QtdDisciplinas = 0;
        }

        public bool podeMatricular(Disciplina disciplina)
        {
            // Não pode haver mais de 6 disciplinas simultâneas.
            if (QtdDisciplinas >= 6) return false;
            // Não pode estar matriculado em duas disciplinas de cursos diferentes.
            if (Curso != null && disciplina != null && disciplina.Curso != null
                && disciplina.Curso.Id != Curso.Id) return false;
            // Não pode estar matriculado duas vezes na mesma disciplina.
            for (int i = 0; i < QtdDisciplinas; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
                    return false;
            }
            return true;
        }

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            if (!podeMatricular(disciplina)) return false;
            Disciplinas[QtdDisciplinas++] = disciplina;
            return true;
        }

        public bool removerDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < QtdDisciplinas; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
                {
                    for (int j = i; j < QtdDisciplinas - 1; j++)
                        Disciplinas[j] = Disciplinas[j + 1];
                    Disciplinas[QtdDisciplinas - 1] = null;
                    QtdDisciplinas--;
                    return true;
                }
            }
            return false;
        }
    }
}
