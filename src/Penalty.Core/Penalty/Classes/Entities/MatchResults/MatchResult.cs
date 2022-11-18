using Abp.Domain.Entities.Auditing;
using Penalty.Penalty.Classes.Entities.Matches;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults
{
    public class MatchResult : FullAuditedEntity<Guid>
    {
      //  [ForeignKey("MatchId")]
        public Guid MatchId { get; set; }
        public Match Match { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime MatchEndingDate { get; set; }
        public DateTime MatchEndingTime { get; set; }
        public string? Description { get; set; }
    }
}
