using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugOfWarCSharp.Entities
{
    public class TeamScore
    {
        public string TeamId { get; set; }
        public int Score { get; set; }

        public TeamScore(string teamId, int score)
        {
            this.TeamId = teamId;
            this.Score = score;
        }
    }
}
