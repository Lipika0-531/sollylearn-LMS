using SollyLearn.API.Models.Domain;

namespace SollyLearn.API.Repository
{
    public interface IImageRepository
    {

        Task<Image> Upload(Image image);
    }
}
