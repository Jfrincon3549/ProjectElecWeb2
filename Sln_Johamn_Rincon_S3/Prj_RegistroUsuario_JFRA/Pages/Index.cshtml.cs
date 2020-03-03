using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Prj_RegistroUsuario_JFRA.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public RegistroUsuario registro { get; set; }
        [BindProperty]
        public IFormFile Upload { get; set; }
        [BindProperty]
        public string result { get; set; }

        public IEnumerable<SelectListItem>ObtenerListaGenero(string dataValueField, string dataTextField) {
            return new SelectList(Genero.ListaGeneros, dataValueField, dataTextField, 1);
        }
        private IWebHostEnvironment _evironment;
        public IndexModel(IWebHostEnvironment evironment)
        {
            _evironment = evironment;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid) 
            {
                registro.ProfilePicture = Guid.NewGuid().ToString();
                string path = Path.Combine(_evironment.ContentRootPath, "Registros");
                SubirImagServidor();
                RegistroUsuario.CreateRegistroUsuarioFIle(path, registro);
                Genero gen = Genero.ObtenerDescripcionDeLista(int.Parse(registro.Gender));
                result = "UserName: "+registro.UserName+ "Contraseña: " + registro.Password + " Genero:" + gen.Descripcion;
                return RedirectToPage("Summary", "RegistroUsuario", new { profilepicture = registro.ProfilePicture });
            }
            return Page();
        }
        private void SubirImagServidor()
        {
            var file = Path.Combine(_evironment.ContentRootPath, "wwwroot\\Uploads", registro.ProfilePicture+".jpg");
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                Upload.CopyToAsync(fileStream);
            }
        }
        
    }
}
