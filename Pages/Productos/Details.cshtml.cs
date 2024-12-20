using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proy_Identity.Identity;
using Proy_Identity.Models;

namespace Proy_Identity.Pages.Productos
{
    public class DetailsModel : PageModel
    {
        private readonly Proy_Identity.Identity.MyIdentityDBContext _context;

        public DetailsModel(Proy_Identity.Identity.MyIdentityDBContext context)
        {
            _context = context;
        }

        public Producto Producto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                Producto = producto;
            }
            return Page();
        }
    }
}
