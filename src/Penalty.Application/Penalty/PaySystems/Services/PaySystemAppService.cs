using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.PaySystems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PaySystems.Services
{
    public class PaySystemAppService : PenaltyAppServiceBase,IPaySystemAppService
    {
        private readonly IPaySystemDomainService _paySystemDomainService;

        public PaySystemAppService(IPaySystemDomainService paySystemDomainService)
        {
            _paySystemDomainService = paySystemDomainService;
        }

        public string AddNewPayment(CreatePaySystemDto paySystem)
        {
            var ps = ObjectMapper.Map<PaySystem>(paySystem);
            var createdUrl = _paySystemDomainService.AddNewPayment(ps);
            return createdUrl;
        }
    }
}
