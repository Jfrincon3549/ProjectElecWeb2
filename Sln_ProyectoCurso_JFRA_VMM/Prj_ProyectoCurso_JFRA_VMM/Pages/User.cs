using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prj_ProyectoCurso_JFRA_VMM.Pages
{
    public class User
    {
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        [MinLength(6, ErrorMessage = "El Nombre debe tener minimo 6 caracteres.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "La contraseña es obligatoria!!"), MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres.")]
        public string Password { get; set; }
    }
}
