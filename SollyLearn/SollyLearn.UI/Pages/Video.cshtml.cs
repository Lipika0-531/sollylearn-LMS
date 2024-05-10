using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SollyLearn.UI.Models.DTO;
using SollyLearn.UI.Models.Service;

namespace SollyLearn.UI.Pages
{
    public class VideoModel : PageModel
    {

        private readonly VideoService _videoService;

        public VideoDTO[] Videos { get; private set; }


        public VideoModel(VideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task OnGetAsync(Guid techstackId)
        {
            Videos = (await _videoService.OnGetAsync(techstackId)).ToArray();
        }


    }
}
