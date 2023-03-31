using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        public bool CheckExistEnrollment(int alunoId, int turmaId);

        public int GetCountEnrolled(int turmaId);

        public void DeleteEnrollment(int alunoId, int turmaId);

    }
}