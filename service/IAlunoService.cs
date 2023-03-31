using teste_desafio.domain.entities;

namespace teste_desafio.service
{
    public interface IAlunoService
    {
        public void Register(Aluno aluno, int turmaId);
        public void Update(Aluno aluno, int id);
        public void Delete(int aluno);
        public List<Aluno> GetAll();
    }
}