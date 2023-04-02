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

        public Task Delete(int id)
        {
           throw new NotImplementedException();
        }

        public async Task DeleteEnrollment(int alunoId, int turmaId)
        {
            var matricula = _context.matricula!.Where(matricula => matricula.AlunoId == alunoId && matricula.TurmaId == turmaId).FirstOrDefault();
            if (matricula == null)
            {
                throw new EntityNotFound("Não foi possivel deletar este dado. Matricula não encontrada");
            }
            _context.Remove(matricula);
            await _context.SaveChangesAsync();
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

        public async Task Register(Matricula entidade)
        {
            _context.matricula!.Add(entidade);
            await _context.SaveChangesAsync();
        }
        public Task Update(Matricula entidade, int id)
        {
            throw new NotImplementedException();
        }
    }
}