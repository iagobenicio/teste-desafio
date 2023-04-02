using teste_desafio.domain.entities;
using teste_desafio.repositories;

namespace teste_desafio.service
{
    public class MatriculaService : IMatriculaService
    {
        
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
            
        }

        public async Task EnrollAluno(Matricula matricula)
        {   

            if (_matriculaRepository.CheckExistEnrollment(matricula.AlunoId, matricula.TurmaId))
            {
                throw new Exception("Este aluno já esta matriculado nesta turma");
            }

            if (_matriculaRepository.GetCountEnrolled(matricula.TurmaId) >= 5)
            {
                throw new Exception("Não foi possivel matricular o aluno. Esta turma já atingiu o limite de alunos matriculados");
            }

            await _matriculaRepository.Register(matricula);
           
        }

        public List<Matricula> GetAll()
        {
            return _matriculaRepository.GetAll();
        }

        public async Task Delete(int alunoId, int turmaId)
        {   
            await _matriculaRepository.DeleteEnrollment(alunoId,turmaId);
        }
    }
}