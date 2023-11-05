using DemoPage.Repository.Entities;

namespace DemoPage.Repository.Repositories.Interfaces
{
    public interface IOgImageRepository
    {
        Task<List<OgImage>> GetOgImagesAsync();
    }
}
