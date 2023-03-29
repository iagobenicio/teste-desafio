using teste_desafio.context;
using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {   
        
        private readonly MatriculaContext _context;

        MatriculaRepository(MatriculaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.matricula!.Find(id);
        }

        public List<Matricula> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool PossuiMatricula(int alunoId, int turmaId)
        {
            throw new NotImplementedException();
        }

        public void Save(Matricula entidade)
        {
            throw new NotImplementedException();
        }
        public void Update(Matricula entidade, int id)
        {
            throw new NotImplementedException();
        }
    }
}