using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PendingInvitationPayments
{
    public interface IPendingInvitationPaymentAppService : IApplicationService
    {
        public Task<double> GetUserDeservedBalance(long UserId);
        public Task<bool> PayForUserInvitations(long UserId, double Balance);
    }
}
