using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Dto
{
    public class UpdateBetDto : EntityDto<Guid>
    {
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public double BetBalance { get; set; }
        public int PayMethodId { get; set; }
        public DateTime BettingDate { get; set; }
        public string? Description { get; set; }
    }
}
