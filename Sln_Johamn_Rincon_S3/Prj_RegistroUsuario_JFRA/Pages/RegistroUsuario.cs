using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Prj_RegistroUsuario_JFRA.Pages
{
    public class RegistroUsuario
    {
       
        [Required(ErrorMessage ="El Nombre es obligatorio.")]
        [MinLength(6, ErrorMessage = "El Nombre debe tener minimo 6 caracteres.")]
        public string UserName { get; set; }

        
        [Required(ErrorMessage = "La contraseña es obligatoria!!"), MinLength(6, ErrorMessage = "La contraseña debe tener minimo 6 caracteres.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de la contraseña es obligatoria!!"),
            Compare(nameof(Password), ErrorMessage = "La contraseña y la confirmación de la contraseña debe ser el mismo valor.")]
        public string Password2 { get; set; }

        public string Gender { get; set; }
        public string ProfilePicture { get; set; }

        public override string ToString()
        {
            return UserName + "|" + Password + "|"+Gender+"|"+ ProfilePicture;
        }
        public static void CreateRegistroUsuarioFIle(String ruta, RegistroUsuario reg)
        {
            ruta += "\\Registro.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(ruta, true)) 
            {
                file.WriteLine(reg);
            }
        }
    }
}
