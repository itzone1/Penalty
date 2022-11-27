using Penalty.Penalty.Classes.Entities.BetResult.Dto;
using Penalty.Penalty.Classes.Entities.BetResults.Services;
using Penalty.Penalty.Classes.RootEntities.Bets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PendingPayments
{
    public class PendingPaymentAppService : PenaltyAppServiceBase, IPendingPaymentAppService
    {
        private readonly IBetResultDomainService betResultDomainService;

        public PendingPaymentAppService(IBetResultDomainService betResultDomainService)
        {
            this.betResultDomainService = betResultDomainService;
        }

        public async Task<IList<BetResultDto>> GetAllNotPaidBetResults()
        {
            var bets = await betResultDomainService.GetAllNotPaidBetResults();
            var betsDto = ObjectMapper.Map<IList<BetResultDto>>(bets);
            return betsDto;
        }

        public async Task<bool> PayForUserBet(Guid BetResultId, double Balance)
        {
            return await betResultDomainService.PayForUserBet(BetResultId, Balance);
        }
    }
}
