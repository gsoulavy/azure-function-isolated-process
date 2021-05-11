namespace Function.IsolatedProcess.Functions
{
    using System.Threading.Tasks;

    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Extensions.Logging;

    using Services;

    // ReSharper disable once UnusedType.Global
    public class HttpEndpoint
    {
        private readonly ILogger<HttpEndpoint> _logger;
        private readonly IHttpResponderService _responderService;

        public HttpEndpoint(IHttpResponderService responderService, ILogger<HttpEndpoint> logger)
        {
            _responderService = responderService;
            _logger = logger;
        }

        [Function(nameof(HttpEndpoint))]
        // ReSharper disable once UnusedMember.Global
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequestData req)
        {
            _logger.LogInformation("message logged");

            return await _responderService.ProcessRequestAsync(req);
        }
    }
}
