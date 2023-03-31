using System.ComponentModel.DataAnnotations;

namespace teste_desafio.domain.entities
{
    public class Matricula
    {   
        [Required]
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        
        [Required]
        public int TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}