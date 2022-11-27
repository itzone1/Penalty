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
        public Task<InvitedUser> RegisterNewInvitedUser(string name, string surname, string emailAddress, string userName, string plainPassword, long inviterId);
        public Task<double> GetUserDeservedBalance(long UserId);
        public Task<bool> PayForUserInvitations(long UserId,double Balance);
    }
}
