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

        public async Task<string> AddNewPayment(Guid BetId)
        {
            var createdUrl = await _paySystemDomainService.AddNewPayment(BetId);
            return createdUrl;
        }
        public IList<PaySystemDto> GetAll()
        { 
            var list = _paySystemDomainService.GetAll();
            return ObjectMapper.Map<List<PaySystemDto>>(list);
        }
    }
}
