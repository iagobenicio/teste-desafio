using System.ComponentModel.DataAnnotations;

namespace teste_desafio.domain.entities
{
    public class Aluno 
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Cpf { get; set; }

        [Required]
        public string? Email { get; set; }
        
        public ICollection<Matricula>? Matricula { get; set; }

        public void MatricularAluno(int turmaId)
        {   
            Matricula = new List<Matricula>();

            Matricula.Add(new Matricula{
                AlunoId = this.Id,
                TurmaId = turmaId
            });

        }
    }
}