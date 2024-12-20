using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proy_Identity.Identity;
using Proy_Identity.Models;

namespace Proy_Identity.Pages.Productos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Proy_Identity.Identity.MyIdentityDBContext _context;

        public IndexModel(Proy_Identity.Identity.MyIdentityDBContext context)
        {
            _context = context;
        }

        public IList<Producto> Producto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Producto = await _context.Productos.ToListAsync();
        }
    }
}
