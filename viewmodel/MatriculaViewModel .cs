using System.ComponentModel.DataAnnotations;

namespace teste_desafio.viewmodel
{
    public class MatriculaViewModel 
    {   

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public int TurmaId { get; set; }
    }
}