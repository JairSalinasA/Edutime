using System.ComponentModel.DataAnnotations;

namespace EduTime.Presentation.ViewModels
{
    public class CursoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del curso no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [StringLength(255, ErrorMessage = "La descripción no puede tener más de 255 caracteres.")]
        public string Descripcion { get; set; }
    }
}
