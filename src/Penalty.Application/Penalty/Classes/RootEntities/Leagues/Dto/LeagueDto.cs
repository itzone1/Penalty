using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Indexes.LeagueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Dto
{
    public class LeagueDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid LeagueTypeId { get; set; }
        public IList<TeamDto> Teams { get; set; }
        public LeagueDto()
        {
            Teams = new List<TeamDto>();
        }
        public string? Description { get; set; }
    }
}
