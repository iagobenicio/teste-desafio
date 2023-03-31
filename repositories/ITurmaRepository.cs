using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public interface ITurmaRepository : IRepository<Turma>
    {   
        public bool CheckExistTurma(int numeroTurma, int anoTurm);
    }
}