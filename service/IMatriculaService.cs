using teste_desafio.domain.entities;

namespace teste_desafio.service
{
    public interface IMatriculaService
    {
        public Task EnrollAluno(Matricula matricula);
        public List<Matricula> GetAll();
        public Task Delete(int alunoId, int turmaId);
    }
}