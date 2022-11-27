using Abp.Application.Services;
using Penalty.Penalty.Classes.Entities.BetResult.Dto;
using Penalty.Penalty.Classes.RootEntities.Bets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PendingPayments
{
    public interface IPendingPaymentAppService : IApplicationService
    {
        Task<IList<BetResultDto>> GetAllNotPaidBetResults();
        Task<bool> PayForUserBet(Guid BetResultId, double Balance);
    }
}
