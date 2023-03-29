using System.ComponentModel.DataAnnotations;

namespace teste_desafio.domain.entities
{
    public class Turma
    {
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public int Ano { get; set; }

        public ICollection<Matricula>? Matricula {get;set;}
    }
}