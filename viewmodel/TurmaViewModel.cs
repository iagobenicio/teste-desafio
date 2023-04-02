using System.ComponentModel.DataAnnotations;

namespace teste_desafio.viewmodel
{
    public class TurmaViewModel
    {   

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório", AllowEmptyStrings = false)]
        public int Ano { get; set; }
    }
}