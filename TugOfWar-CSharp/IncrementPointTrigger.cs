using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace TugOfWarCSharp
{
    public static class IncrementPointTrigger
    {
        [FunctionName("IncrementPointTrigger")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            [Queue("scorequeue", Connection = "AzureWebJobsStorage")]ICollector<string> outputQueueMessage,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            // Get the TeamId
            string teamId = data?.teamId;

            // Queue Point
            outputQueueMessage.Add(teamId);

            return req.CreateResponse(HttpStatusCode.OK);
        }

    }
       
}