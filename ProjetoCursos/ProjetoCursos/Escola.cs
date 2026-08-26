using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Escola
    {
        public Curso[] Cursos { get; private set; }
        public int QtdCursos { get; private set; }

        public Escola()
        {
            Cursos = new Curso[5];
            QtdCursos = 0;
        }

        public bool adicionarCurso(Curso curso)
        {
            // Limite máximo de 5 cursos por escola.
            if (QtdCursos >= 5) return false;
            // Não permite cursos duplicados (mesmo id).
            for (int i = 0; i < QtdCursos; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == curso.Id)
                    return false;
            }
            Cursos[QtdCursos++] = curso;
            return true;
        }

        public Curso pesquisarCurso(Curso curso)
        {
            if (curso == null) return null;
            for (int i = 0; i < QtdCursos; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == curso.Id)
                    return Cursos[i];
            }
            return null;
        }

        public Curso pesquisarCursoPorId(int id)
        {
            for (int i = 0; i < QtdCursos; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == id)
                    return Cursos[i];
            }
            return null;
        }

        public bool removerCurso(Curso curso)
        {
            // Só permite remover cursos sem disciplinas associadas.
            if (curso.QtdDisciplinas > 0) return false;

            for (int i = 0; i < QtdCursos; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == curso.Id)
                {
                    for (int j = i; j < QtdCursos - 1; j++)
                        Cursos[j] = Cursos[j + 1];
                    Cursos[QtdCursos - 1] = null;
                    QtdCursos--;
                    return true;
                }
            }
            return false;
        }
    }
}
