using Dapper;
using DemoPage.Repository.DbContexts;
using DemoPage.Repository.Entities;
using DemoPage.Repository.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace DemoPage.Repository.Repositories
{
    public class OgImageRepository : IOgImageRepository
    {
        private readonly ILogger<OgImageRepository> _logger;
        private readonly SqliteDbContext _context;

        public OgImageRepository(
            ILogger<OgImageRepository> logger,
            SqliteDbContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<OgImage>> GetOgImagesAsync()
        {
            try
            {
                using (var conn = _context.Connection())
                {
                    conn.Open();

                    string sql = @"
                        SELECT * FROM DemoPage
                    ";

                    IEnumerable<OgImage> results = await conn.QueryAsync<OgImage>(sql);
                    return results.ToList();
                }
            }
            catch ( Exception ex )
            {
                _logger.LogError("{error}", ex.ToString());
                throw;
            }
        }
    }
}
