using Abp.Application.Services;
using Penalty.Penalty.PaySystems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PaySystems.Services
{
    public interface IPaySystemAppService : IApplicationService
    {
        public Task<string> AddNewPayment(Guid BetId);
        
    }
}
