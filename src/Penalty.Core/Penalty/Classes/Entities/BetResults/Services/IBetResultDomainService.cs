using Abp.Domain.Services;
using Penalty.Penalty.Classes.Entities.MatchResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.BetResults.Services
{
    public interface IBetResultDomainService : IDomainService
    {
        IList<BetResult> GetAll();
        IList<BetResult> GetAllUserBets();
        Task<IList<BetResult>> GetAllBetResultsAsync();
        Task<BetResult> GetbyId(Guid id);
        Task<BetResult> Insert(BetResult betResult);
        Task<BetResult> Update(BetResult betResult);
        void Delete(BetResult betResult);
        Task<BetResult> GetBetResultbyBetId(Guid id);
        Task<bool> PayForUserBet(Guid BetResultId, double Balance);
    }
}
