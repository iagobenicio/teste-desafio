using teste_desafio.domain.entities;
using teste_desafio.repositories;

namespace teste_desafio.service
{
    public class MatriculaService : IMatriculaService
    {
        
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository, IAlunoRepository alunoRepository, ITurmaRepository turmaRepository)
        {
            _matriculaRepository = matriculaRepository;
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            
        }

        public async Task EnrollAluno(Matricula matricula)
        {   
            if (!_alunoRepository.CheckExistAlunoById(matricula.AlunoId))
            {
                throw new Exception("Não foi possivel matricular o aluno. Este aluno não existe");
            }
         
            if (!_turmaRepository.CheckExistTurmaById(matricula.TurmaId))
            {
                throw new Exception("Não foi possivel matricular o aluno. Esta turma não existe");
            }

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