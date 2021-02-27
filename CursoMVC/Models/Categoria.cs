using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models
{
    public class Categoria
    {
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        public string Descricao { get; set; }
    }
}
