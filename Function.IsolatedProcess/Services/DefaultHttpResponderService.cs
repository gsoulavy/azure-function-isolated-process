namespace Function.IsolatedProcess.Services
{
    using System.Dynamic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.Azure.Functions.Worker.Http;

    using Newtonsoft.Json;

    public class DefaultHttpResponderService : IHttpResponderService
    {
        public async Task<HttpResponseData> ProcessRequestAsync(HttpRequestData httpRequest)
        {
            using var streamReader = new StreamReader(httpRequest.Body);
            dynamic body = JsonConvert.DeserializeObject<ExpandoObject>(await streamReader.ReadToEndAsync());
            string name = body?.name;

            var response = httpRequest.CreateResponse(HttpStatusCode.OK);

            response.Headers.Add("Date", "Mon, 18 Jul 2016 16:06:00 GMT");
            response.Headers.Add("Content", "Content - Type: text / html; charset = utf - 8");

            await response.WriteStringAsync($"Hi {name}, Welcome to .NET 5!!");

            return response;
        }
    }
}
