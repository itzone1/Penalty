using Abp.Domain.Entities.Auditing;
using Penalty.Penalty.Classes.Entities.MatchResults;
using Penalty.Penalty.Classes.RootEntities.Bets;
using Penalty.Penalty.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.BetResults
{
    public class BetResult : FullAuditedEntity<Guid>
    {
       // [ForeignKey("Bet")]
        public Guid BetId { get; set; }
        public Bet Bet { get; set; }
        public Result Result { get; set; }
       // [ForeignKey("MatchResult")]
        public Guid MatchResultId { get; set; }
        public MatchResult MatchResult { get; set; }
        public double DeservedBalance
        {
            get
            {
                return Bet.BetBalance * Bet.Match.ODD;
            }
        }
        public bool isPaid { get; set; }
        public string? Description { get; set; }
    }
}
