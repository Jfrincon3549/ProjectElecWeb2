using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Prj_RegistroUsuario_JFRA.Pages
{
    public class SummaryModel : PageModel
    {   
        [BindProperty(Name = "profilepicture", SupportsGet = true)]
        public string Profilepicture { get; set; }

        [BindProperty]
        public RegistroUsuario regist { get; set; }

        private IWebHostEnvironment _environment;

        public SummaryModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        private RegistroUsuario ObtenerRegistroUsuarioxID(string profpic)
        {
            RegistroUsuario reg = new RegistroUsuario();
            var lista = System.IO.File.ReadAllLines(Path.Combine(_environment.ContentRootPath, "Registros") + "\\Registro.txt");
            foreach (string str in lista) 
            {
                if (str.Split("|").Length == 4)
                    if (str.Split("|")[3] == profpic)
                    {
                        reg.UserName = str.Split("|")[0];
                        reg.Password = str.Split("|")[1];
                        reg.Gender = Genero.ObtenerDescripcionDeLista(int.Parse(str.Split("|")[2])).Descripcion;
                        reg.ProfilePicture = str.Split("|")[3] + "jpg";
                    }
            }
            return reg;
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }

        public void OnGetRegistroUsuario()
        {
            regist = ObtenerRegistroUsuarioxID(Profilepicture);
        }
        public void OnGet()
        {

        }
    }
}