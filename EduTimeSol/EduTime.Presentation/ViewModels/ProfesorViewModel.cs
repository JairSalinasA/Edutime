using System.ComponentModel.DataAnnotations;

namespace EduTime.Presentation.ViewModels
{
    public class ProfesorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del profesor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del profesor no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del profesor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido del profesor no puede tener más de 100 caracteres.")]
        public string Apellido { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string Email { get; set; }
    }
}
