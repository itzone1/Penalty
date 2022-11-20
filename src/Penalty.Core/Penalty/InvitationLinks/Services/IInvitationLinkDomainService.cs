﻿using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitationLinks.Services
{
    public interface IInvitationLinkDomainService : IDomainService
    {
        public string GetUserInvitationLink();
        public string GenerateUserInvitationLink();
    }
}
