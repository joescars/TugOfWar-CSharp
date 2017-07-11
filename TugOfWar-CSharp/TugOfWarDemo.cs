using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace TugOfWarCSharp
{
    public static class TugOfWarDemo
    {
        [FunctionName("CreateTeamSettings")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "options", "post", Route = null)]HttpRequestMessage req,
            [Table("gamesettings", Connection = "AzureWebJobsStorage")]ICollector<TeamSetting> outTable,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();
            string team1 = data?.team1;
            string team2 = data?.team2;

            // Create team settings
            TeamSetting ts = new TeamSetting(team1, team2);

            // Store to table
            outTable.Add(ts);

            // Return team settings
            return req.CreateResponse(HttpStatusCode.Created, ts);
            
        }

        public class TeamSetting : TableEntity
        {
            public string Team1 { get; set; }
            public string Team1Id { get; set; }
            public string Team2 { get; set; }
            public string Team2Id { get; set; }

            public TeamSetting(string team1Name, string team2Name)
            {
                this.PartitionKey = "setting";
                this.RowKey = getInvertedTicks().ToString();
                this.Team1 = team1Name;
                this.Team1Id = Guid.NewGuid().ToString();
                this.Team2 = team2Name;
                this.Team2Id = Guid.NewGuid().ToString();
            }

        }

        public class Teams
        {
            public string team1 { get; set; }
            public string team2 { get; set; }
        }

        private static long getInvertedTicks()
        {
            DateTime dt = DateTime.UtcNow;

            long yourTicks = DateTime.MaxValue.Ticks - dt.Ticks;

            return yourTicks;
        }
    }
}