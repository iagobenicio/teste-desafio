using teste_desafio.domain.entities;

namespace teste_desafio.service
{
    public interface ITurmaService
    {   
        public Task Register(Turma turma);
        public Task Update(Turma turma, int id);
        public Task Delete(int turmaId);
        public List<Turma> GetAll();
    }
}