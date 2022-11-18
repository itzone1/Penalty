using Abp.Application.Services.Dto;
using Penalty.Penalty.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Dto
{
    public class CreateTeamDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? ClubId { get; set; }
        //public Guid? LeagueId { get; set; }
        public bool? isNationalTeam { get; set; }
        public string? Description { get; set; }
    }
}
