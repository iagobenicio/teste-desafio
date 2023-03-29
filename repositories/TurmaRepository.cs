using teste_desafio.context;
using teste_desafio.domain.entities;

namespace teste_desafio.repositories
{
    public class TurmaRepository : IRepository<Turma>
    {   
        private readonly MatriculaContext _context;

        public TurmaRepository(MatriculaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
           var turma = _context.turma!.Find(id);
           if(turma != null)
           {
             _context.Remove(turma);
             _context.SaveChanges();
           }
        }   

        public List<Turma> GetAll()
        {
           return _context.turma!.ToList();
        }

        public void Save(Turma entidade)
        {
            _context.Add(entidade);
            _context.SaveChanges();
        }

        public void Update(Turma entidade, int id)
        {
            var turma = _context.turma!.Find(id);

            if (turma != null)
            {
                turma.Numero = entidade.Numero;
                turma.Ano = entidade.Ano; 
                _context.SaveChanges();
            }
        }
    }
}