using KariyerApp.BusinessLogic.Interfaces;
using KariyerApp.Core.Entities;
using Nest;

namespace KariyerApp.BusinessLogic.Services
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly ElasticClient _client;

        public ElasticSearchService(ElasticClient client)
        {
            _client = client;
        }

        public async Task IndexJobAdvertisementAsync(JobAdvertisement jobAdvertisement)
        {
            try
            {
                //burada dto kullanılabilir.
                jobAdvertisement.Compensations = [];

                var response = await _client.IndexAsync(jobAdvertisement, s => s.Index("job_advertisement"));

                if (!response.IsValid)
                    throw new Exception("Elasticsearch'e eklenirken hata oluştu.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<JobAdvertisement>> GetJobAdvertisements(int days)
        {
            var startDate = DateTime.Now.AddDays(-1 * days);

            var queryResult = await _client.SearchAsync<JobAdvertisement>(s => s.Index("job_advertisement").Query(q => q.DateRange(f => f.Field(d => d.CreatedDate).GreaterThanOrEquals(startDate))));
            
            if (!queryResult.IsValid)
                return [];
            
            return queryResult.Documents.ToList();
        }
    }
}
