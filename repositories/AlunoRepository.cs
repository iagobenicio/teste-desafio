using teste_desafio.domain.entities;
using teste_desafio.context;

namespace teste_desafio.repositories
{
    public class AlunoRepository : IAlunoRepository
    {   

        private readonly MatriculaContext _context;

        public AlunoRepository(MatriculaContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var aluno = _context.alunos!.Find(id);
            if (aluno != null)
            {
                _context.Remove(aluno);
                _context.SaveChanges();
            }
        }

        public List<Aluno> GetAll()
        {
            return _context.alunos!.ToList();
        }

        public void Save(Aluno entidade)
        {   
            _context.Add(entidade);
            _context.SaveChanges();
        }

        public int CheckExistCpf(string cpf)
        {
           return _context.alunos!.Where(aluno => aluno.Cpf == cpf).Count();
        }
        
        public void Update(Aluno entidade, int id)
        {
            var aluno = _context.alunos!.Find(id);

            if (aluno != null)
            {   
                aluno.Cpf = entidade.Cpf;
                aluno.Email = entidade.Email;
                aluno.Name = entidade.Name;

                _context.Update(aluno);
                _context.SaveChanges();
            }
        }
    }
}