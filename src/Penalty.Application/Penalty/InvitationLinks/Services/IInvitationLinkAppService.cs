using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitationLinks.Services
{
    public interface IInvitationLinkAppService : IApplicationService
    {
        public Task<string> GetUserInvitationLink();
    }
}
