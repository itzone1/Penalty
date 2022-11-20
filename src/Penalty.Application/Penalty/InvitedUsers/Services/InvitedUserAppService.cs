using Abp.Domain.Repositories;
using Penalty.Authorization.Accounts.Dto;
using Penalty.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers.Services
{
    public class InvitedUserAppService : PenaltyAppServiceBase, IInvitedUserAppService
    {
        private readonly IInvitedUserDomainService _invitedUserDomainService;

        public InvitedUserAppService(IInvitedUserDomainService invitedUserDomainService)
        {
            _invitedUserDomainService = invitedUserDomainService;
        }

        public async Task<InvitedUser> RegisterByUserInvite(string name, string surname, string emailAddress, string userName, string plainPassword, long inviterId)
        {
            return await _invitedUserDomainService.RegisterNewInvitedUser(name,surname,emailAddress,userName,plainPassword, inviterId);
        }
    }
}
