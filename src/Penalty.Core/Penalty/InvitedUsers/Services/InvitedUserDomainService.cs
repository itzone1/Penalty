using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Penalty.Authorization.Users;
using Penalty.Penalty.InvitationLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers.Services
{
    public class InvitedUserDomainService : IInvitedUserDomainService
    {
        private readonly IRepository<InvitedUser, Guid> _repository;
        private IAbpSession AbpSession { get; set; }
        private readonly IRepository<InvitationLink, Guid> _inviteLinkRepository;


        public InvitedUserDomainService(IRepository<InvitedUser, Guid> repository, IAbpSession abpSession)
        {
            _repository = repository;
            AbpSession = abpSession;
        }


        public async Task<InvitedUser> RegisterNewInvitedUser(User user, string InvitationUrl)
        {
            var inviter = _inviteLinkRepository.GetAll().FirstOrDefault(x => x.GeneratedUrl == InvitationUrl).User;
            InvitedUser invitedUser = new InvitedUser()
            {
                User = user,
                UserId = user.Id,
                InvitedByUser = inviter,
                InvitedByUserId = inviter.Id,
                isActivated = false
            };
            return await _repository.InsertOrUpdateAsync(invitedUser);
        }
    }
}
