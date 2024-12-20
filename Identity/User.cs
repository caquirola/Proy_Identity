using Microsoft.AspNetCore.Identity;

namespace Proy_Identity.Identity
{
    public class User : IdentityUser
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string password { get; set; }

    }
}