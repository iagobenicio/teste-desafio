using teste_desafio.domain.entities;
using teste_desafio.repositories;

namespace teste_desafio.service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly ITurmaRepository _turmaRepository;

        public AlunoService(IAlunoRepository repository, IMatriculaRepository matriculaRepository, ITurmaRepository turmaRepository)
        {
            _repository = repository;
            _matriculaRepository = matriculaRepository;
            _turmaRepository = turmaRepository;
        }

        public void Delete(int alunoId)
        {
            _repository.Delete(alunoId);
        }

        public List<Aluno> GetAll()
        {   
            var alunos = _repository.GetAll();
            
            return alunos;
        }

        public void Register(Aluno aluno, int turmaId)
        {
            var existCpfOrEmail = _repository.CheckExistCpfOrEmail(aluno.Cpf!,aluno.Email!);

            if (existCpfOrEmail)
            {
                throw new Exception("Este cpf já está cadastrado ou este email já esta sendo usado");
            }
            if (!_turmaRepository.CheckExistTurmaById(turmaId))
            {
                throw new Exception("Não foi possivel matricular o aluno. Esta turma não existe");
            }
            if (_matriculaRepository.GetCountEnrolled(turmaId) >= 5)
            {
                throw new Exception("Não foi possivel matricular o aluno. Esta turma já atingiu o limite de alunos matriculados");
            }

            aluno.MatricularAluno(turmaId);

            _repository.Register(aluno);

        }

        public void Update(Aluno aluno, int id)
        {
            
            var existEmail = _repository.CheckExistEmail(aluno.Email!, id);

            if (existEmail)
            {
                throw new Exception("Este email já está sendo usado");
            }

            _repository.Update(aluno,id);

        }

    }
}