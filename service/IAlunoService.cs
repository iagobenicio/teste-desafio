using teste_desafio.domain.entities;

namespace teste_desafio.service
{
    public interface IAlunoService
    {
        public Task Register(Aluno aluno, int turmaId);
        public Task Update(Aluno aluno, int id);
        public Task Delete(int aluno);
        public List<Aluno> GetAll();
    }
}