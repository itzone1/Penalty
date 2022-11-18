using AutoMapper;
using Penalty.Penalty.Indexes.Countries.Dto;
using Penalty.Penalty.Indexes.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Indexes.LeagueTypes.Dto;

namespace Penalty.Penalty.Indexes.LeagueTypes.Map
{
    public class LeagueTypesMapProfile : Profile
    {
        public LeagueTypesMapProfile()
        {
            CreateMap<LeagueType, LeagueTypeDto>();
            CreateMap<LeagueType, CreateLeagueTypeDto>();
            CreateMap<LeagueType, UpdateLeagueTypeDto>();
            CreateMap<LeagueTypeDto, LeagueType>();
            CreateMap<CreateLeagueTypeDto, LeagueType>();
            CreateMap<UpdateLeagueTypeDto, LeagueType>();
        }
    }
}
