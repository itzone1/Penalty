using Abp.Domain.Entities.Auditing;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.Entities.Matches;
using Penalty.Penalty.Enums;
using Penalty.Penalty.PayMethods;
using Penalty.Penalty.PaySystems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets
{
    public class Bet : FullAuditedAggregateRoot<Guid>
    {
        #region User
      //  [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        #endregion
        #region Match
     //   [ForeignKey("Match")]
        public Guid MatchId { get; set; }
        public Match Match { get; set; }
        #endregion
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public double BetBalance { get; set; }
        #region PayMethod
      //  [ForeignKey("PayMethod")]
        public Guid? PayMethodId { get; set; }
        public PayMethod? PayMethod { get; set; }
        #endregion
        public DateTime BettingDate { get; set; }
        public BetStatus BetStatus { get; set; }
        public string? Description { get; set; }
        public bool isPaid { get; set; }
        [ForeignKey("PaySystem")]
        public Guid PaySystemId { get; set; }
        public PaySystem PaySystem { get; set; }
    }
}
