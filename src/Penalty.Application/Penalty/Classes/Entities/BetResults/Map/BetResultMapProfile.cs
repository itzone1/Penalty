using AutoMapper;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Classes.Entities.BetResult.Dto;

namespace Penalty.Penalty.Classes.Entities.BetResults.Map
{
    public class BetResultMapProfile : Profile
    {
        public BetResultMapProfile()
        {
            CreateMap<BetResult, BetResultDto>();
            CreateMap<BetResult, CreateBetResultDto>();
            CreateMap<BetResult, UpdateBetResultDto>();
            CreateMap<BetResultDto, BetResult>();
            CreateMap<CreateBetResultDto, BetResult>();
            CreateMap<UpdateBetResultDto, BetResult>();
        }
    }
}
