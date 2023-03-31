using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        public bool CheckExistCpf(string cpf);

        public bool CheckExistEmail(string email);
    }
}