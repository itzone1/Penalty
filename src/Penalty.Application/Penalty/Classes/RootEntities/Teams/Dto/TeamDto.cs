using Abp.Application.Services.Dto;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using Penalty.Penalty.Indexes.Clubs.Dto;
using Penalty.Penalty.Indexes.Countries;
using Penalty.Penalty.Indexes.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Dto
{
    public class TeamDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public Guid? CountryId { get; set; }
        public CountryDto? Country { get; set; }
        public Guid? ClubId { get; set; }
        public ClubDto? Club { get; set; }
        //public Guid? LeagueId { get; set; }
        //public LeagueDto? League { get; set; }
        public bool? isNationalTeam { get; set; }
        public string? Description { get; set; }
    }
}
