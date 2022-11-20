using Abp.Application.Services;
using Penalty.Authorization.Accounts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers.Services
{
    public interface IInvitedUserAppService : IApplicationService
    {
        Task<InvitedUser> RegisterByUserInvite(string name, string surname, string emailAddress, string userName, string plainPassword, long inviterId);
    }
}
