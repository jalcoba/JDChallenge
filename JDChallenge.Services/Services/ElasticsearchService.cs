using Elastic.Clients.Elasticsearch;
using JDChallenge.Services.Interfaces;
using Serilog;

namespace JDChallenge.Services.Services;

public class ElasticsearchService : IElasticsearchService
{
    private readonly ElasticsearchClient _client;

    public ElasticsearchService(string? url)
    {
        ArgumentNullException.ThrowIfNull(url);
        _client = new ElasticsearchClient(new Uri(url));
    }

    public async Task IndexDocument<T>(T document, string id) where T : class
    {
        try
        {
            var indexResponse = await _client.IndexAsync(document, idx => idx
                .Index(typeof(T).Name.ToLower())
                .Id(id)
            );

            if (!indexResponse.IsSuccess())
            {
                throw new ArgumentException(indexResponse.DebugInformation);
            }
        }
        catch (Exception ex)
        {
            Log.Error("Error to index document:{@document}, id:{@id}, ex:{@ex}", document, id, ex);
        }
    }
}
