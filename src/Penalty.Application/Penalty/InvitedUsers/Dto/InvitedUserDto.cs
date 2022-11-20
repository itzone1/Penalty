using Abp.Application.Services.Dto;
using Penalty.Authorization.Users;
using Penalty.Users.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers.Dto
{
    public class InvitedUserDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public UserDto User { get; set; }
        public long InvitedByUserId { get; set; }
        public UserDto InvitedByUser { get; set; }

    }
}
