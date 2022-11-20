using Abp.Domain.Services;
using Penalty.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers.Services
{
    public interface IInvitedUserDomainService : IDomainService
    {
        public Task<InvitedUser> RegisterNewInvitedUser(User user,string InvitationUrl);
    }
}
