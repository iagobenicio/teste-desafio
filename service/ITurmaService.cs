using teste_desafio.domain.entities;

namespace teste_desafio.service
{
    public interface ITurmaService
    {   
        public void Register(Turma turma);
        public void Update(Turma turma, int id);
        public void Delete(int turmaId);
        public List<Turma> GetAll();
    }
}