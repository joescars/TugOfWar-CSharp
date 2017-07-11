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
    public static class GetTeamSettings
    {
        // Return Team Settings
        [FunctionName("GetTeamSettings")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequestMessage req,
            [Table("gamesettings", Connection = "AzureWebJobsStorage")]CloudTable inTable,
            TraceWriter log)
        {
            log.Info("### Get Team Settings Triggered ###");

            // Get Team Settings
            TableQuery<TeamSetting> query = new TableQuery<TeamSetting>().Take(1);
            var data = inTable.ExecuteQuery(query).Take(1);

            // Return team settings
            return req.CreateResponse(HttpStatusCode.OK, data);

        }
    }
}