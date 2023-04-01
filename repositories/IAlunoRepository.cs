using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        public bool CheckExistCpfOrEmail(string cpf, string email);

        public bool CheckExistEmail(string email,int id);
    }
}