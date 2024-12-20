using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Proy_Identity.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Proy_Identity.Pages.Account

{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public LoginDTO Login { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validar que el modelo tenga datos v�lidos
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Datos inv�lidos.");
                return Page();
            }

            // Buscar el usuario por correo
            var user = await _userManager.FindByEmailAsync(Login.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario no encontrado.");
                return Page();
            }

            // Intentar iniciar sesi�n
            var result = await _signInManager.PasswordSignInAsync(user.UserName, Login.Password, true, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Contrase�a incorrecta.");
                return Page();
            }

            // Redirigir al usuario a la p�gina principal
            return LocalRedirect("~/");
        }
    }
}