using teste_desafio.domain.entities;
using teste_desafio.repositories;

namespace teste_desafio.service
{
    public class TurmaService : ITurmaService
    {   
        private readonly ITurmaRepository _repository;
        private readonly IMatriculaRepository _matriculaRepository;

        public TurmaService(ITurmaRepository repository, IMatriculaRepository matriculaRepository)
        {
            _repository = repository;
            _matriculaRepository = matriculaRepository;
        }

        public async Task Delete(int turmaId)
        {   
            if (_matriculaRepository.GetCountEnrolled(turmaId) >= 1)
            {
                throw new Exception("Esta turma não pode ser deletada pois há alunos matriculados nela");
            }

            await _repository.Delete(turmaId);
        }

        public List<Turma> GetAll()
        {
           var turmas = _repository.GetAll();

           return turmas;
        }

        public async Task Register(Turma turma)
        {     

            var existTumra = _repository.CheckExistTurma(turma.Numero,turma.Ano);

            if (existTumra)
            {
                throw new Exception("Já existe uma turma cadastrada com este número e ano");
            }

            await _repository.Register(turma);
        }

        public async Task Update(Turma turma, int id)
        {
            
            var existTumra = _repository.CheckExistTurma(turma.Numero,turma.Ano);

            if (existTumra)
            {
                throw new Exception("Já existe uma turma cadastrada com este número e ano");
            }
            
            await _repository.Update(turma,id);
        }
    }
}