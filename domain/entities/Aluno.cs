using System.ComponentModel.DataAnnotations;

namespace teste_desafio.domain.entities
{
    public class Aluno 
    {
        public int Id { get; set; }

        [Required]
        public string? Name {get; set;}

        [Required]
        public string? Cpf {get; set;}

        [Required]
        public string? Email {get; set;}
        
        public ICollection<Matricula>? Matricula;
    }
}