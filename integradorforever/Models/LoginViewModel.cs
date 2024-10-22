using System.ComponentModel.DataAnnotations;

namespace integradorforever.Models
{
    
        public class LoginViewModel
        {
            [Required]
            [StringLength(50)]
            public string Nombre { get; set; }

            [Required]
            [StringLength(20)]
            [DataType(DataType.Password)]
            public string contrasena { get; set; }
        }
    
}
