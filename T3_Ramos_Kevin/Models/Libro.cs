using System.ComponentModel.DataAnnotations;

namespace T3_Ramos_Kevin.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del Titulo es obligatorio.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatoria.")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El tema es obligatorio.")]    
        public string Tema { get; set; }

        [Required(ErrorMessage = "La editorial es obligatorio.")]
        public String Editorial { get; set; }

        [Required(ErrorMessage = "El año de publicacion es obligatorio.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "El año de inicio de operaciones debe tener 4 dígitos.")]
        [Range(1900, 3000, ErrorMessage = "El año de inicio de operaciones debe estar entre 1900 a 3000.")]
        public string AnioPublicacion { get; set; }

        [Required(ErrorMessage = "Las paginas es obligatorio.")]
        [Range(10, 1000, ErrorMessage = "El año de inicio de operaciones debe estar entre 10 a 1000.")]
        public string Paginas { get; set; }

        [Required(ErrorMessage = "La categoria es obligatorio.")]
        public string Categoria { get; set; }

    }
}
