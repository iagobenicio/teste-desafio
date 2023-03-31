using teste_desafio.domain.entities;

namespace teste_desafio.service
{
    public interface IMatriculaService
    {
        public void EnrollAluno(Matricula matricula);
        public List<Matricula> GetAll();
        public void Delete(int alunoId, int turmaId);
    }
}