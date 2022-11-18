using AutoMapper;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Map
{
    public class MatchResultMapProfile : Profile
    {
        public MatchResultMapProfile()
        {
            CreateMap<MatchResult, MatchResultDto>();
            CreateMap<MatchResult, CreateMatchResultDto>();
            CreateMap<MatchResult, UpdateMatchResultDto>();
            CreateMap<MatchResultDto, MatchResult>();
            CreateMap<CreateMatchResultDto, MatchResult>();
            CreateMap<UpdateMatchResultDto, MatchResult>();
        }
    }
}
