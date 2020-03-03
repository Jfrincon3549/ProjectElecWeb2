using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prj_RegistroUsuario_JFRA.Pages
{
    public class Genero
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public static List<Genero> ListaGeneros = new List<Genero> {
            new Genero{ Id = 1, Descripcion="Masculino"},new Genero{ Id = 0, Descripcion="Femenino"}
        };
        public static Genero ObtenerDescripcionDeLista(int indice)
        {
            return ListaGeneros[indice];
        }
        
    }
}
