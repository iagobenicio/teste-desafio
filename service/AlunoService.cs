using teste_desafio.domain.entities;
using teste_desafio.repositories;

namespace teste_desafio.service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;
        private readonly IMatriculaRepository _matriculaRepository;

        public AlunoService(IAlunoRepository repository, IMatriculaRepository matriculaRepository)
        {
            _repository = repository;
            _matriculaRepository = matriculaRepository;
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
            var existCpf = _repository.CheckExistCpf(aluno.Cpf!);
            

            if (existCpf)
            {
                throw new Exception("Este aluno já está cadastrado");
            }
            
            var existEmail = _repository.CheckExistEmail(aluno.Email!);

            if (existEmail)
            {
                throw new Exception("Este email já está sendo usado");
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
            
            var existEmail = _repository.CheckExistEmail(aluno.Email!);

            if (existEmail)
            {
                throw new Exception("Este email já está sendo usado");
            }

            _repository.Update(aluno,id);

        }

    }
}