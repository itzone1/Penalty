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
        private readonly IBetResultDomainService _betResultDomainService;
        private readonly IBetDomainService _betDomainService;

        public PendingPaymentAppService(IBetResultDomainService betResultDomainService, IBetDomainService betDomainService)
        {
            this._betResultDomainService = betResultDomainService;
            _betDomainService = betDomainService;
        }

        public async Task<IList<PendingPaymentDto>> GetAllAsync()
        {
            var items = _betResultDomainService.GetAll().Where(x => x.IsPaid == false && x.Result == Enums.Result.WonBet);
            var bets = _betDomainService.GetAll();
            var result = new List<PendingPaymentDto>();
            foreach (var item in items)
            {
                result.Add(new PendingPaymentDto()
                {
                    User = bets.FirstOrDefault(x => x.Id == item.BetId).User.FullName,
                    HomeTeam = bets.FirstOrDefault(x => x.Id == item.BetId).Match.HomeTeam,
                    AwayTeam = bets.FirstOrDefault(x => x.Id == item.BetId).Match.AwayTeam,
                    BetBalance = bets.FirstOrDefault(x => x.Id == item.BetId).BetBalance,
                    DeservedBalance = item.DeservedBalance,
                });
            }
            return result;
        }

        public async Task<IList<BetResultDto>> GetAllNotPaidBetResults()
        {
            var bets = await _betResultDomainService.GetAllNotPaidBetResults();
            var betsDto = ObjectMapper.Map<IList<BetResultDto>>(bets);
            return betsDto;
        }

        public async Task<bool> PayForUserBet(Guid BetResultId, double Balance)
        {
            return await _betResultDomainService.PayForUserBet(BetResultId, Balance);
        }
    }
}
