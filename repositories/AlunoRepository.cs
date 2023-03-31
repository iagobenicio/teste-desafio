using teste_desafio.domain.entities;
using teste_desafio.context;
using teste_desafio.failures;

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
            if (aluno == null)
            {
                throw new EntityNotFound("Não foi possivel deletar este dado. Aluno não encontrado");
            }
            _context.Remove(aluno);
            _context.SaveChanges();
        }

        public List<Aluno> GetAll()
        {
            return _context.alunos!.ToList();
        }

        public void Register(Aluno entidade)
        {   
            _context.alunos!.Add(entidade);
            _context.SaveChanges();
        }

        public bool CheckExistCpf(string cpf)
        {
            return _context.alunos!.Any(aluno => aluno.Cpf!.ToUpper() == cpf.ToUpper());
        }

        public bool CheckExistEmail(string email)
        {
            return _context.alunos!.Any(Aluno => Aluno.Email!.ToUpper() == email.ToUpper());
        }
        
        public void Update(Aluno entidade, int id)
        {
            var aluno = _context.alunos!.Find(id);

            if (aluno == null)
            {   
                throw new EntityNotFound("Não foi possivel fazer as alterações. Aluno não encontrado");
            }
            aluno.Email = entidade.Email;
            aluno.Name = entidade.Name;

            _context.Update(aluno);
            _context.SaveChanges();
        }
    }
}