using System.ComponentModel.DataAnnotations;

namespace EduTime.Presentation.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de usuario no puede tener más de 100 caracteres.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 255 caracteres.")]
        public string Contraseña { get; set; }

        public int RolId { get; set; }
    }
}
