using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.Matches.Dto
{
    public class MatchDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid LeagueId { get; set; }
        public LeagueDto League { get; set; }
        public Guid HomeTeamId { get; set; }
        public TeamDto HomeTeam { get; set; }
        public Guid AwayTeamId { get; set; }
        public TeamDto AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime ExpectedEndingTime { get; set; }
        public int MatchStatus { get; set; }
        public double ODD { get; set; }
        public string? Description { get; set; }
    }
}
