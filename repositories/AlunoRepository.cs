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

        public async Task Delete(int id)
        {
            var aluno = _context.alunos!.Find(id);
            if (aluno == null)
            {
                throw new EntityNotFound("Não foi possivel deletar este dado. Aluno não encontrado");
            }
            _context.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public List<Aluno> GetAll()
        {
            return _context.alunos!.ToList();
        }

        public async Task Register(Aluno entidade)
        {   
            _context.alunos!.Add(entidade);
            await _context.SaveChangesAsync();
        }

        public bool CheckExistCpfOrEmail(string cpf,string email)
        {   
            return _context.alunos!.Any(aluno => aluno.Cpf!.ToUpper() == cpf.ToUpper() || aluno.Email!.ToUpper() == email.ToUpper());
        }

        public bool CheckExistEmail(string email, int id)
        {
            return _context.alunos!.Any(Aluno => Aluno.Email!.ToUpper() == email.ToUpper() && Aluno.Id != id);
        }
        
        public bool CheckExistAlunoById(int id)
        {
            return _context.alunos!.Any(aluno => aluno.Id == id);
        }

        public async Task Update(Aluno entidade, int id)
        {
            var aluno = _context.alunos!.Find(id);

            if (aluno == null)
            {   
                throw new EntityNotFound("Não foi possivel fazer as alterações. Aluno não encontrado");
            }
            aluno.Email = entidade.Email;
            aluno.Name = entidade.Name;
            
            _context.Update(aluno);
            await _context.SaveChangesAsync();
        }
    }
}