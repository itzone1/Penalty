using Abp.Application.Services.Dto;
using Penalty.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Dto
{
    public class CreateBetDto : EntityDto<Guid>
    {
        public Guid MatchId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public double BetBalance { get; set; }
        public Guid? PayMethodId { get; set; }
        public string? Description { get; set; }
    }
}
