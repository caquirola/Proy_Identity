using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Proy_Identity.Pages
{
    [Authorize]
    public class PrivacyAdminModel : PageModel
    {
        private readonly ILogger<PrivacyAdminModel> _logger;


        public PrivacyAdminModel(ILogger<PrivacyAdminModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
        }
    }
}

