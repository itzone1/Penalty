using AutoMapper;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Classes.RootEntities.Bets.Dto;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Map
{
    public class BetMapProfile : Profile
    {
        public BetMapProfile()
        {
            CreateMap<Bet, BetDto>();
            CreateMap<Bet, CreateBetDto>();
            CreateMap<Bet, UpdateBetDto>();
            CreateMap<BetDto, Bet>();
            CreateMap<CreateBetDto, Bet>();
            CreateMap<UpdateBetDto, Bet>();
        }
    }
}
