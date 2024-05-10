using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SollyLearn.UI.Models.DTO;
using System.Text;
using System.Text.Json;


namespace SollyLearn.UI.Pages
{
    public class AuthenticationModel : PageModel
    {
        [BindProperty]
        public RegisterRequestDto RegisterRequestDto { get; set; }

        private readonly IHttpClientFactory _clientFactory;

        public AuthenticationModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

      /*  public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (ModelState.IsValid)
            {
                var httpClient = _clientFactory.CreateClient();

                var json = System.Text.Json.JsonSerializer.Serialize(RegisterRequestDto, typeof(RegisterRequestDto));
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("/api/Register", data);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", responseData);
                }
            }

            return Page();
        }*/
    }
}
