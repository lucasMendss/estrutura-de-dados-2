using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCursos
{
    internal class Program
    {
        static Escola escola = new Escola();
        static int idAtualAluno = 1;
        static int idAtualDisciplina = 1;
        static int idAtualCurso = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("===== GERENCIAMENTO DE ALUNOS, DISCIPLINAS E CURSOS =====");

            bool programaFinalizado = false;
            int opcao;

            while (!programaFinalizado)
            {
                Console.WriteLine("\n--- MENU DE OPÇÕES ---");
                Console.WriteLine("- 0: Sair");
                Console.WriteLine("- 1: Adicionar curso");
                Console.WriteLine("- 2: Pesquisar curso");
                Console.WriteLine("- 3: Remover curso");
                Console.WriteLine("- 4: Adicionar disciplina em curso");
                Console.WriteLine("- 5: Pesquisar disciplina");
                Console.WriteLine("- 6: Remover disciplina de curso");
                Console.WriteLine("- 7: Matricular aluno em disciplina");
                Console.WriteLine("- 8: Remover aluno de disciplina");
                Console.WriteLine("- 9: Pesquisar aluno");
                Console.WriteLine("----------------------");

                Console.Write("\nDigite uma opção: ");
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida!");
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Finalizando sistema...");
                        programaFinalizado = true;
                        break;
                    case 1:
                        adicionarCurso();
                        break;
                    case 2:
                        pesquisarCurso();
                        break;
                    case 3:
                        removerCurso();
                        break;
                    case 4:
                        adicionarDisciplinaEmCurso();
                        break;
                    case 5:
                        pesquisarDisciplina();
                        break;
                    case 6:
                        removerDisciplinaDeCurso();
                        break;
                    case 7:
                        matricularAlunoEmDisciplina();
                        break;
                    case 8:
                        removerAlunoDeDisciplina();
                        break;
                    case 9:
                        pesquisarAluno();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        // ---------- CURSO ----------

        static void adicionarCurso()
        {
            if (escola.QtdCursos >= 5)
            {
                Console.WriteLine("Limite máximo de 5 cursos atingido.");
                return;
            }

            Console.Write("Digite a descrição do curso: ");
            string descricao = Console.ReadLine();

            Curso curso = new Curso(idAtualCurso, descricao);
            if (escola.adicionarCurso(curso))
            {
                Console.WriteLine($"Curso '{descricao}' adicionado com sucesso (id={idAtualCurso}).");
                idAtualCurso++;
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o curso.");
            }
        }

        static void pesquisarCurso()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(id);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            Console.WriteLine($"Curso {curso.Id}: {curso.Descricao}");
            if (curso.QtdDisciplinas == 0)
            {
                Console.WriteLine("  Sem disciplinas associadas.");
            }
            else
            {
                Console.WriteLine($"  Disciplinas ({curso.QtdDisciplinas}/12):");
                for (int i = 0; i < curso.QtdDisciplinas; i++)
                {
                    Disciplina d = curso.Disciplinas[i];
                    Console.WriteLine($"    - [{d.Id}] {d.Descricao} ({d.QtdAlunos}/15 aluno(s))");
                }
            }
        }

        static void removerCurso()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(id);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            if (curso.QtdDisciplinas > 0)
            {
                Console.WriteLine("Não é possível remover: o curso possui disciplinas associadas.");
                return;
            }

            string descricao = curso.Descricao;
            if (escola.removerCurso(curso))
                Console.WriteLine($"Curso '{descricao}' removido com sucesso.");
            else
                Console.WriteLine("Não foi possível remover o curso.");
        }

        // ---------- DISCIPLINA ----------

        static void adicionarDisciplinaEmCurso()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCurso))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(idCurso);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            if (curso.QtdDisciplinas >= 12)
            {
                Console.WriteLine("Limite máximo de 12 disciplinas atingido neste curso.");
                return;
            }

            Console.Write("Digite a descrição da disciplina: ");
            string descricao = Console.ReadLine();

            Disciplina disciplina = new Disciplina(idAtualDisciplina, descricao, curso);
            if (curso.adicionarDisciplina(disciplina))
            {
                Console.WriteLine($"Disciplina '{descricao}' adicionada ao curso '{curso.Descricao}' (id={idAtualDisciplina}).");
                idAtualDisciplina++;
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar a disciplina.");
            }
        }

        static void pesquisarDisciplina()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCurso))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(idCurso);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisc))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Disciplina disc = curso.pesquisarDisciplinaPorId(idDisc);
            if (disc == null)
            {
                Console.WriteLine("Disciplina não encontrada neste curso.");
                return;
            }

            Console.WriteLine($"Disciplina {disc.Id}: {disc.Descricao} (curso: {curso.Descricao})");
            if (disc.QtdAlunos == 0)
            {
                Console.WriteLine("  Sem alunos matriculados.");
            }
            else
            {
                Console.WriteLine($"  Alunos matriculados ({disc.QtdAlunos}/15):");
                for (int i = 0; i < disc.QtdAlunos; i++)
                {
                    Aluno a = disc.Alunos[i];
                    Console.WriteLine($"    - [{a.Id}] {a.Nome}");
                }
            }
        }

        static void removerDisciplinaDeCurso()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCurso))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(idCurso);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisc))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Disciplina disc = curso.pesquisarDisciplinaPorId(idDisc);
            if (disc == null)
            {
                Console.WriteLine("Disciplina não encontrada neste curso.");
                return;
            }

            if (disc.QtdAlunos > 0)
            {
                Console.WriteLine("Não é possível remover: a disciplina possui alunos matriculados.");
                return;
            }

            string descricao = disc.Descricao;
            if (curso.removerDisciplina(disc))
                Console.WriteLine($"Disciplina '{descricao}' removida do curso '{curso.Descricao}'.");
            else
                Console.WriteLine("Não foi possível remover a disciplina.");
        }

        // ---------- ALUNO ----------

        static void matricularAlunoEmDisciplina()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCurso))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(idCurso);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisc))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Disciplina disc = curso.pesquisarDisciplinaPorId(idDisc);
            if (disc == null)
            {
                Console.WriteLine("Disciplina não encontrada neste curso.");
                return;
            }

            if (disc.QtdAlunos >= 15)
            {
                Console.WriteLine("Disciplina já atingiu o limite de 15 alunos.");
                return;
            }

            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            Aluno aluno = new Aluno(idAtualAluno, nome, curso);
            if (disc.matricularAluno(aluno))
            {
                Console.WriteLine($"Aluno '{nome}' matriculado na disciplina '{disc.Descricao}' (id={idAtualAluno}).");
                idAtualAluno++;
            }
            else
            {
                Console.WriteLine("Não foi possível matricular o aluno.");
            }
        }

        static void removerAlunoDeDisciplina()
        {
            Console.Write("Digite o id do curso: ");
            if (!int.TryParse(Console.ReadLine(), out int idCurso))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Curso curso = escola.pesquisarCursoPorId(idCurso);
            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            Console.Write("Digite o id da disciplina: ");
            if (!int.TryParse(Console.ReadLine(), out int idDisc))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Disciplina disc = curso.pesquisarDisciplinaPorId(idDisc);
            if (disc == null)
            {
                Console.WriteLine("Disciplina não encontrada neste curso.");
                return;
            }

            Console.Write("Digite o id do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int idAluno))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Aluno aluno = null;
            for (int i = 0; i < disc.QtdAlunos; i++)
            {
                if (disc.Alunos[i].Id == idAluno)
                {
                    aluno = disc.Alunos[i];
                    break;
                }
            }

            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado nesta disciplina.");
                return;
            }

            string nome = aluno.Nome;
            if (disc.desmatricularAluno(aluno))
                Console.WriteLine($"Aluno '{nome}' removido da disciplina '{disc.Descricao}'.");
            else
                Console.WriteLine("Não foi possível remover o aluno.");
        }

        static void pesquisarAluno()
        {
            Console.Write("Digite o id do aluno: ");
            if (!int.TryParse(Console.ReadLine(), out int idAluno))
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            Aluno aluno = localizarAluno(idAluno);
            if (aluno == null)
            {
                Console.WriteLine("Aluno não encontrado.");
                return;
            }

            Console.WriteLine($"Aluno {aluno.Id}: {aluno.Nome}");
            if (aluno.Curso != null)
                Console.WriteLine($"  Curso: [{aluno.Curso.Id}] {aluno.Curso.Descricao}");

            if (aluno.QtdDisciplinas == 0)
            {
                Console.WriteLine("  Sem disciplinas matriculadas.");
            }
            else
            {
                Console.WriteLine($"  Disciplinas matriculadas ({aluno.QtdDisciplinas}/6):");
                for (int i = 0; i < aluno.QtdDisciplinas; i++)
                {
                    Disciplina d = aluno.Disciplinas[i];
                    string nomeCurso = d.Curso != null ? d.Curso.Descricao : "(sem curso)";
                    Console.WriteLine($"    - [{d.Id}] {d.Descricao} (curso: {nomeCurso})");
                }
            }
        }

        static Aluno localizarAluno(int idAluno)
        {
            for (int i = 0; i < escola.QtdCursos; i++)
            {
                Curso curso = escola.Cursos[i];
                for (int j = 0; j < curso.QtdDisciplinas; j++)
                {
                    Disciplina disc = curso.Disciplinas[j];
                    for (int k = 0; k < disc.QtdAlunos; k++)
                    {
                        if (disc.Alunos[k].Id == idAluno)
                            return disc.Alunos[k];
                    }
                }
            }
            return null;
        }
    }
}
