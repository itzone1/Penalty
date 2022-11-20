using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitationLinks.Services
{
    public class InvitationLinkAppService : PenaltyAppServiceBase, IInvitationLinkAppService
    {
        private readonly InvitationLinkDomainService _invitationLinkDomainService;

        public InvitationLinkAppService(InvitationLinkDomainService invitationLinkDomainService)
        {
            _invitationLinkDomainService = invitationLinkDomainService;
        }

        public async Task<string> GetUserInvitationLink()
        {
            return await _invitationLinkDomainService.GetUserInvitationLink();
        }
    }
}
