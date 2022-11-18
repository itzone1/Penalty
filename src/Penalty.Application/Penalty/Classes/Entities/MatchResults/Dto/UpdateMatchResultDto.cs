using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Dto
{
    public class UpdateMatchResultDto : EntityDto<Guid>
    {
        public Guid MatchId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime MatchEndingDate { get; set; }
        public DateTime MatchEndingTime { get; set; }
        public string? Description { get; set; }
    }
}
