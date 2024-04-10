using CS.BO.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS.UIX.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public IEnumerable<BO.Entities.User> Users { get; set; }
        public UserRepository rep = new UserRepository();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
            Users = rep.GetAlls();
        }
    }
}
