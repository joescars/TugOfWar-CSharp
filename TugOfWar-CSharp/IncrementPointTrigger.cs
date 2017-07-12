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
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            [Queue("scorequeue", Connection = "AzureWebJobsStorage")]out string outputQueueMessage,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = req.Content.ReadAsAsync<object>();
            //TeamPoint tp = new TeamPoint(data?.teamId);
            string teamId = data?.teamId;

            outputQueueMessage = teamId;
            

        }

    }

    public class TeamPoint 
    {
        public string TeamId { get; set; }

        public TeamPoint() {}

        public TeamPoint(string teamId)
        {
            this.TeamId = teamId;
        }
    }
}