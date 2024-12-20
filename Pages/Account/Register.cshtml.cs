using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Proy_Identity.Identity;

namespace Proy_Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public RegisterDTO Register { get; set; }
        public string ReturnUrl { get; set; }
        public RegisterModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnpostAsync()
        {
            if (Register.password != Register.confirmpassword)
            {
                throw new Exception("Las contraseñas no coinciden");
            }

            var user = new User();

            user.UserName = Register.email;
            user.nombre = Register.nombre;
            user.apellido = Register.apellido;
            user.telefono = Register.telefono;
            user.direccion = Register.direccion;
            user.Email = Register.email;
            user.password = Register.password;

            var res = await _userManager.CreateAsync(user, Register.password);
            if (!res.Succeeded)
            {
                throw new Exception("Error al crear el usuario");
            }
            if (ReturnUrl == null)
            {
                ReturnUrl = Url.Content("~/");
            }
            return LocalRedirect(ReturnUrl);

        }

    }

}