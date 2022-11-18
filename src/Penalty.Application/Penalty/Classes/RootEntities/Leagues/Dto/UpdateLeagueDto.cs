using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Dto
{
    public class UpdateLeagueDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid LeagueTypeId { get; set; }
        public string? Description { get; set; }
    }
}
