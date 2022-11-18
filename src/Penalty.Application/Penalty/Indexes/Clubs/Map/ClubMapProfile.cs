using AutoMapper;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.Indexes.Clubs.Dto;

namespace Penalty.Penalty.Indexes.Clubs.Map
{
    public class ClubMapProfile : Profile
    {
        public ClubMapProfile()
        {
            CreateMap<Club, ClubDto>();
            CreateMap<Club, CreateClubDto>();
            CreateMap<Club, UpdateClubDto>();
            CreateMap<ClubDto, Club>();
            CreateMap<CreateClubDto, Club>();
            CreateMap<UpdateClubDto, Club>();
        }
    }
}
