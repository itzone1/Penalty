using AutoMapper;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Classes.Entities.Matches.Dto;

namespace Penalty.Penalty.Classes.Entities.Matches.Map
{
    public class MatchMapProfile : Profile
    {
        public MatchMapProfile()
        {
            CreateMap<Match, MatchDto>();
            CreateMap<Match, CreateMatchDto>();
            CreateMap<Match, UpdateMatchDto>();
            CreateMap<MatchDto, Match>();
            CreateMap<CreateMatchDto, Match>();
            CreateMap<UpdateMatchDto, Match>();
        }
    }
}
