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
        public string team1 { get; set; }
        public string team1Id { get; set; }
        public string team2 { get; set; }
        public string team2Id { get; set; }

        public TeamSetting(string team1Name, string team2Name)
        {
            this.PartitionKey = "setting";
            this.RowKey = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString();
            this.team1 = team1Name;
            this.team1Id = Guid.NewGuid().ToString();
            this.team2 = team2Name;
            this.team2Id = Guid.NewGuid().ToString();
        }

        public TeamSetting() { }

    }


}
