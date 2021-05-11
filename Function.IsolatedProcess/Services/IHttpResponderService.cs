namespace Function.IsolatedProcess.Services
{
    using System.Threading.Tasks;

    using Microsoft.Azure.Functions.Worker.Http;

    public interface IHttpResponderService
    {
        Task<HttpResponseData> ProcessRequestAsync(HttpRequestData httpRequest);
    }
}
