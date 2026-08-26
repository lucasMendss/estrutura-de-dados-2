using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Curso
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public Disciplina[] Disciplinas { get; private set; }
        public int QtdDisciplinas { get; private set; }

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Disciplinas = new Disciplina[12];
            QtdDisciplinas = 0;
        }

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            // Limite máximo de 12 disciplinas por curso.
            if (QtdDisciplinas >= 12) return false;
            // Não permite disciplinas duplicadas (mesmo id).
            for (int i = 0; i < QtdDisciplinas; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
                    return false;
            }
            Disciplinas[QtdDisciplinas++] = disciplina;
            return true;
        }

        public Disciplina pesquisarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null) return null;
            for (int i = 0; i < QtdDisciplinas; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
                    return Disciplinas[i];
            }
            return null;
        }

        public Disciplina pesquisarDisciplinaPorId(int id)
        {
            for (int i = 0; i < QtdDisciplinas; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == id)
                    return Disciplinas[i];
            }
            return null;
        }

        public bool removerDisciplina(Disciplina disciplina)
        {
            // Só permite remover disciplinas sem alunos matriculados.
            if (disciplina.QtdAlunos > 0) return false;

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
