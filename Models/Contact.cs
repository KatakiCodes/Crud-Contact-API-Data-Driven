using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30, ErrorMessage = "O nome deve ter no maximo 30 caracteres!")]
        [MinLength(3, ErrorMessage = "O nome deve ter no minimo e caracteres!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O numero deve ser informado!")]
        public int Number { get; set; }
    }
}