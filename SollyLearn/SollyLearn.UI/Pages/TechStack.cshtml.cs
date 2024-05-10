using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SollyLearn.UI.Models.DTO;
using SollyLearn.UI.Models.Service;

namespace SollyLearn.UI.Pages
{
    public class TechStackModel : PageModel
    {
        private readonly TechStackService _techStackService;

        public IEnumerable<TechStackDTO> TechStacks { get; private set; }

        public TechStackModel(TechStackService techStackService)
        {
            _techStackService = techStackService;
        }

        public async Task OnGetAsync()
        {
            TechStacks = await _techStackService.GetTechStacksAsync();
        }
    }
}
