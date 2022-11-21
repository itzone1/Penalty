using AutoMapper;
using Penalty.Penalty.InvitationLinks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitationLinks.Map
{
    public class InvitationLinkProfile : Profile
    {
        public InvitationLinkProfile()
        {
            CreateMap<InvitationLink, InvitationLinkDto>();
            CreateMap<InvitationLinkDto, InvitationLink>();
        }
    }
}
