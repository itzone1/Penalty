using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.Matches.Dto
{
    public class UpdateMatchDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid LeagueId { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime ExpectedEndingTime { get; set; }
        public int MatchStatusId { get; set; }
        public double ODD { get; set; }
        public string? Description { get; set; }
    }
}
