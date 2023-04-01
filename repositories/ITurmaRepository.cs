using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public interface ITurmaRepository : IRepository<Turma>
    {   
        public bool CheckExistTurmaById(int turmaID);

        public bool CheckExistTurma(int numeroTurma, int anoTurm);

    }
}