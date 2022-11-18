using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using Penalty.Penalty.Classes.RootEntities.Bets;
using Penalty.Penalty.Classes.RootEntities.Bets.Dto;
using Penalty.Penalty.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.BetResult.Dto
{
    public class BetResultDto : EntityDto<Guid>
    {
        public Guid BetId { get; set; }
        public BetDto Bet { get; set; }
        public int Result { get; set; }
        public Guid MatchResultId { get; set; }
        public MatchResultDto MatchResult { get; set; }
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
