using AutoMapper;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Map
{
    public class LeagueMapProfile : Profile
    {
        public LeagueMapProfile()
        {
            CreateMap<League, LeagueDto>();
            CreateMap<League, CreateLeagueDto>();
            CreateMap<League, UpdateLeagueDto>();
            CreateMap<LeagueDto, League>();
            CreateMap<CreateLeagueDto, League>();
            CreateMap<UpdateLeagueDto, League>();
        }
    }
}
