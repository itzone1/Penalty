using AutoMapper;
using Penalty.Penalty.InvitedUsers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers.Map
{
    public class InvitedUserProfile : Profile
    {
        public InvitedUserProfile()
        {
            CreateMap<InvitedUser,InvitedUserDto>();
            CreateMap<InvitedUserDto, InvitedUser>();
        }
    }
}
