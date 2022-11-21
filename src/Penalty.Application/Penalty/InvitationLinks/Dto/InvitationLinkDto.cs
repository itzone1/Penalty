using Abp.Application.Services.Dto;
using Penalty.Authorization.Users;
using Penalty.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitationLinks.Dto
{
    public class InvitationLinkDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public UserDto User { get; set; }
        public string GeneratedUrl { get; set; }
    }
}
