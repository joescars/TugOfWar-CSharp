using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using TugOfWarCSharp.Entities;

namespace TugOfWarCSharp
{
    public static class IncrementPointUpdate
    {
        [FunctionName("IncrementPointUpdate")]
        public static void Run(
            [QueueTrigger("scorequeue", Connection = "AzureWebJobsStorage")]string TeamId,
            [Table("teampoints", Connection = "AzureWebJobsStorage")]ICollector<TeamPoint> outTable,
            TraceWriter log)
        {
            log.Info("### Increment Point Update ###");

            // Create team settings
            TeamPoint tp = new TeamPoint(TeamId);

            // Store to table
            outTable.Add(tp);
        }

    }
       
}