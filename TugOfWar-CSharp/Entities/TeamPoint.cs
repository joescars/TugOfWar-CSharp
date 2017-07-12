using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugOfWarCSharp.Entities
{
    public class TeamPoint : TableEntity
    {
        public string TeamId { get; set; }

        public TeamPoint() {}

        public TeamPoint(string teamId)
        {
            this.PartitionKey = "point";
            this.RowKey = Guid.NewGuid().ToString();
            this.TeamId = teamId;
        }
    }
}
