using teste_desafio.context;
using teste_desafio.domain.entities;
using teste_desafio.failures;

namespace teste_desafio.repositories
{
    public class TurmaRepository : ITurmaRepository
    {   
        private readonly MatriculaContext _context;

        public TurmaRepository(MatriculaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
           var turma = _context.turma!.Find(id);
           if(turma == null)
           {
             throw new EntityNotFound("Não foi possivel deletar este dado. Turma não encontrada");
           }
            _context.Remove(turma);
            _context.SaveChanges();
        }   

        public List<Turma> GetAll()
        {
           return _context.turma!.ToList();
        }

        public void Register(Turma entidade)
        {
            _context.Add(entidade);
            _context.SaveChanges();
        }

        public void Update(Turma entidade, int id)
        {
            var turma = _context.turma!.Find(id);

            if (turma == null)
            {
                throw new EntityNotFound("Não foi possivel fazer as alterações. Turma não encontrada");
            }
            turma.Numero = entidade.Numero;
            turma.Ano = entidade.Ano; 
            _context.Update(turma);
            _context.SaveChanges();
    
        }
        
        public bool CheckExistTurma(int numeroTurma, int anoTurma)
        {   
            return _context.turma!.Any(turma => turma.Numero == numeroTurma && turma.Ano == anoTurma);
        }
    }
}