using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugOfWarCSharp.Entities
{
    public class TeamSetting : TableEntity
    {
        public string Team1 { get; set; }
        public string Team1Id { get; set; }
        public string Team2 { get; set; }
        public string Team2Id { get; set; }

        public TeamSetting(string team1Name, string team2Name)
        {
            this.PartitionKey = "setting";
            this.RowKey = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString();
            this.Team1 = team1Name;
            this.Team1Id = Guid.NewGuid().ToString();
            this.Team2 = team2Name;
            this.Team2Id = Guid.NewGuid().ToString();
        }

        public TeamSetting() { }

    }


}
