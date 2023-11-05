using DemoPage.Repository.Entities;
using DemoPage.Repository.Repositories.Interfaces;
using DemoPage.Service.OgImageServices.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPage.Service.OgImageServices
{
    public class OgImageService : IOgImageService
    {
        private readonly ILogger<OgImageService> _logger;
        private readonly IOgImageRepository _ogImageRepository;

        public OgImageService(
            ILogger<OgImageService> logger,
            IOgImageRepository ogImageRepository
            )
        {
            _logger = logger;
            _ogImageRepository = ogImageRepository;
        }

        public async Task<List<OgImage>> GetOgImagesAsync()
        {
            return await _ogImageRepository.GetOgImagesAsync();
        }
    }
}
