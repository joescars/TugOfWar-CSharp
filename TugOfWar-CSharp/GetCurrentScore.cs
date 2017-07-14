using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using TugOfWarCSharp.Entities;

namespace TugOfWarCSharp
{
    public static class GetCurrentScore
    {
        [FunctionName("GetCurrentScore")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "options", "post", Route = null)]HttpRequestMessage req,
            [Table("teampoints", Connection = "AzureWebJobsStorage")]CloudTable inTable,
            TraceWriter log)
        {
            log.Info("### Get Current Score Triggered ###");

            dynamic data = await req.Content.ReadAsAsync<object>();
            string teamId = data?.teamId;

            // Get only the records with the corresponding teamId
            TableQuery<TeamPoint> query = new TableQuery<TeamPoint>()
                .Where(TableQuery.GenerateFilterCondition("TeamId", QueryComparisons.Equal, teamId));

            // Get the Score
            int scoreResult = inTable.ExecuteQuery(query).Count();

            TeamScore ts = new TeamScore(teamId, scoreResult);

            // Return the Score
            return req.CreateResponse(HttpStatusCode.OK, ts);
        }

    }
}