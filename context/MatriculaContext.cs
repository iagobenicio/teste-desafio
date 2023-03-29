using Microsoft.EntityFrameworkCore;
using teste_desafio.domain.entities;

namespace teste_desafio.context
{
    public class MatriculaContext : DbContext
    {
        public MatriculaContext(DbContextOptions<MatriculaContext> options) : base(options)
        {

        }

        public DbSet<Aluno>? alunos {get; set; }
        public DbSet<Turma>? turma { get; set; }
        public DbSet<Matricula>? matricula { get; set; }
 
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Matricula>().HasKey(key => new {key.AlunoId,key.TurmaId});
            builder.Entity<Matricula>().HasOne(matri => matri.Turma).WithMany(aln => aln.Matricula).OnDelete(DeleteBehavior.Restrict);
        }
    }
}