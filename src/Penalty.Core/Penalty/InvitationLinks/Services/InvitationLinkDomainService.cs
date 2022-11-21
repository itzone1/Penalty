using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.RootEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitationLinks.Services
{
    public class InvitationLinkDomainService : IInvitationLinkDomainService
    {
        private readonly IRepository<InvitationLink, Guid> _repository;
        private readonly IRepository<GeneralSettings, Guid> _generalSettingsRepository;
        private readonly UserManager _userManager;
        private IAbpSession AbpSession { get; set; }

        public InvitationLinkDomainService(IRepository<InvitationLink, Guid> repository, IRepository<GeneralSettings, Guid> generalSettingsRepository, UserManager userManager, IAbpSession abpSession)
        {
            _repository = repository;
            _generalSettingsRepository = generalSettingsRepository;
            _userManager = userManager;
            AbpSession = abpSession;
        }

        public async Task<string> GenerateUserInvitationLink()
        {
            var settings = _generalSettingsRepository.GetAll().FirstOrDefault();
            InvitationLink invitationLink = new InvitationLink()
            {
                User = _userManager.GetUserById((long)AbpSession.UserId),
                UserId = (long)AbpSession.UserId,
                GeneratedUrl = settings.WebsiteDeafultLink + "/registerinvitelink?id=" + (long)AbpSession.UserId
            };
            await _repository.InsertOrUpdateAsync(invitationLink);
            return invitationLink.GeneratedUrl;
        }

        public async Task<string> GetUserInvitationLink()
        {
            var Link = _repository.GetAll().Where(x => x.UserId == AbpSession.UserId).Select(x => x.GeneratedUrl).FirstOrDefault();
            if(Link == null || Link == String.Empty)
            {
                return await GenerateUserInvitationLink();
            }
            return  Link;
        }
    }
}
