using DemoPage.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPage.Service.OgImageServices.Interfaces
{
    public interface IOgImageService
    {
        Task<List<OgImage>> GetOgImagesAsync();
    }
}
