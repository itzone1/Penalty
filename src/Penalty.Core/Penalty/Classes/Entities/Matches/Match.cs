using Abp.Domain.Entities.Auditing;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.Matches
{
    public class Match : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
       // [ForeignKey("League")]
        public Guid LeagueId { get; set; }
        public League League { get; set; }
       // [ForeignKey("HomeTeam")]
        public Guid HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
      //  [ForeignKey("AwayTeam")]
        public Guid AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime ExpectedEndingTime { get; set; }

        //[ForeignKey("MatchStatus")]
        //public int MatchStatusId { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public double ODD { get; set; }
        public string? Description { get; set; }
    }
}
