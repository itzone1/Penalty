using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.ODDSApiMatches.Services
{
    public interface IODDSApiDoaminService : IDomainService
    {
        Task GetAll();
    }
}
