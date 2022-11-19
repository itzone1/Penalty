using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Dto
{
    public class CreateLeagueDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string LeagueApiKey { get; set; }
        public Guid LeagueTypeId { get; set; }
        public string? Description { get; set; }
    }
}
