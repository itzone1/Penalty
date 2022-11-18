using AutoMapper;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Map
{
    public class TeamMapProfile : Profile
    {
        public TeamMapProfile()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<Team, CreateTeamDto>();
            CreateMap<Team, UpdateTeamDto>();
            CreateMap<TeamDto, Team>();
            CreateMap<CreateTeamDto, Team>();
            CreateMap<UpdateTeamDto, Team>();
        }
    }
}
