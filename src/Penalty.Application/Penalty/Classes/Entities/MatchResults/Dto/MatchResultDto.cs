using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Dto
{
    public class MatchResultDto : EntityDto<Guid>
    {
        public Guid MatchId { get; set; }
        public MatchDto Match { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime MatchEndingDate { get; set; }
        public DateTime MatchEndingTime { get; set; }
        public string? Description { get; set; }
    }
}
