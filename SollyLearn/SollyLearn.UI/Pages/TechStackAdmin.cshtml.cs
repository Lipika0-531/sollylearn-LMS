using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SollyLearn.UI.Models.DTO;
using SollyLearn.UI.Models.Service;

namespace SollyLearn.UI.Pages
{
    public class TechStackAdminModel : PageModel
    {
        private readonly TechStackService _techStackService;

        public IEnumerable<TechStackDTO> TechStacks { get; private set; }
        public Guid UpdateId { get; set; }

        [BindProperty]
        public UpdateTechStackRequestDto UpdateTechStackRequest { get; set; } = new UpdateTechStackRequestDto();


        public TechStackAdminModel(TechStackService techStackService)
        {
            _techStackService = techStackService;
        }

        public async Task OnGetAsync()
        {
            TechStacks = await _techStackService.GetTechStacksAsync();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updatedTechStack = await _techStackService.UpdateTechStackAsync(UpdateId, UpdateTechStackRequest);

            if (updatedTechStack == null)
            {
                // Handle error
                return Page();
            }

            return RedirectToPage("./TechStackAdmin");
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            var deletedTechStack = await _techStackService.DeleteTechStackAsync(id);

            if (deletedTechStack == null)
            {
                // Handle error
                return Page();
            }

            return RedirectToPage("./TechStackAdmin"); // Redirect to the admin tech stack page
        }
    }
}

