using Penalty.Penalty.InvitedUsers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PendingInvitationPayments
{
    public class PendingInvitationPaymentAppService : PenaltyAppServiceBase, IPendingInvitationPaymentAppService
    {
        private readonly InvitedUserDomainService invitedUserDomainService;

        public PendingInvitationPaymentAppService(InvitedUserDomainService invitedUserDomainService)
        {
            this.invitedUserDomainService = invitedUserDomainService;
        }

        public async Task<double> GetUserDeservedBalance(long UserId)
        {
          return await invitedUserDomainService.GetUserDeservedBalance(UserId);
        }

        public async Task<bool> PayForUserInvitations(long UserId, double Balance)
        {
          return await invitedUserDomainService.PayForUserInvitations(UserId, Balance);
        }
    }
}
