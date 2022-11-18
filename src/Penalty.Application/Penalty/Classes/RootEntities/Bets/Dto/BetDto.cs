using Abp.Application.Services.Dto;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using Penalty.Penalty.Enums;
using Penalty.Penalty.PayMethods;
using Penalty.Penalty.PayMethods.Dto;
using Penalty.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Dto
{
    public class BetDto : EntityDto<Guid>
    {
        #region User
        public long UserId { get; set; }
        public UserDto User { get; set; }
        #endregion
        #region Match
        public Guid MatchId { get; set; }
        public MatchDto Match { get; set; }
        #endregion
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public double BetBalance { get; set; }
        #region PayMethod
        public Guid PayMethodId { get; set; }
        public PayMethodDto PayMethod { get; set; }
        #endregion
        public DateTime BettingDate { get; set; }
        public int BetStatus { get; set; }
        public string? Description { get; set; }
    }
}
