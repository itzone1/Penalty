using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager _userManager;
        private readonly UserRegistrationManager _userRegistrationManager;

        private IAbpSession AbpSession { get; set; }
        private readonly IRepository<InvitationLink, Guid> _inviteLinkRepository;


        public InvitedUserDomainService(IRepository<InvitedUser, Guid> repository, IAbpSession abpSession, UserManager userManager, IRepository<InvitationLink, Guid> inviteLinkRepository, UserRegistrationManager userRegistrationManager)
        {
            _repository = repository;
            AbpSession = abpSession;
            _userManager = userManager;
            _inviteLinkRepository = inviteLinkRepository;
            _userRegistrationManager = userRegistrationManager;
        }


        public async Task<InvitedUser> RegisterNewInvitedUser(string name, string surname, string emailAddress, string userName, string plainPassword, long inviterId)
        {
            var user = await _userRegistrationManager.RegisterAsync(
              name,
              surname,
              emailAddress,
              userName,
              plainPassword,
              true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
          );
            var invitedDataExists = _repository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.UserId == user.Id);
            if(invitedDataExists != null)
            {
                return null;
            }
           
            InvitedUser invitedUser = new InvitedUser
            {
                User = _userManager.GetUserById(user.Id),
                UserId = user.Id,
                InvitedByUser = _userManager.GetUserById(inviterId),
                InvitedByUserId = inviterId,
                isActivated = false
            };
            return await _repository.InsertOrUpdateAsync(invitedUser);
        }
    }
}
