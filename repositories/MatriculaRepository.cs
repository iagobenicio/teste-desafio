using teste_desafio.context;
using teste_desafio.domain.entities;
using Microsoft.EntityFrameworkCore;
using teste_desafio.failures;

namespace teste_desafio.repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {   
        
        private readonly MatriculaContext _context;

        public MatriculaRepository(MatriculaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
           throw new NotImplementedException();
        }

        public void DeleteEnrollment(int alunoId, int turmaId)
        {
            var matricula = _context.matricula!.Where(matricula => matricula.AlunoId == alunoId && matricula.TurmaId == turmaId).FirstOrDefault();
            if (matricula == null)
            {
                throw new EntityNotFound("Não foi possivel deletar dado. Matricula não encontrada");
            }
            _context.Remove(matricula);
            _context.SaveChanges();
        }

        public List<Matricula> GetAll()
        {   
            return _context.matricula!.Include(a => a.Aluno).Include(t => t.Turma).ToList();
        }

        public bool CheckExistEnrollment(int alunoId, int turmaId)
        {
            return _context.matricula!.Any(matricula => matricula.AlunoId == alunoId && matricula.TurmaId == turmaId);
        }

        public int GetCountEnrolled(int turmaId)
        {
           return _context.matricula!.Where(matricula => matricula.TurmaId == turmaId).Count();
        }

        public void Register(Matricula entidade)
        {
            _context.matricula!.Add(entidade);
            _context.SaveChanges();
        }
        public void Update(Matricula entidade, int id)
        {
            throw new NotImplementedException();
        }
    }
}