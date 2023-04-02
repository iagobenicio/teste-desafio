using System.ComponentModel.DataAnnotations;

namespace teste_desafio.viewmodel
{
    public class AlunoViewModel 
    {   
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public string? Email { get; set; }
    }
}