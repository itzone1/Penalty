using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Penalty.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.BetResults.Services
{
    public class BetResultDomainService : IBetResultDomainService
    {
        private readonly IRepository<BetResult, Guid> _repository;
        private readonly UserManager _userManager;
        private IAbpSession AbpSession
        {
            get; set;
        }

        public BetResultDomainService(IRepository<BetResult, Guid> repository, UserManager userManager, IAbpSession abpSession)
        {
            _repository = repository;
            _userManager = userManager;
            AbpSession = abpSession;
        }

        public void Delete(BetResult betResult)
        {
            _repository.Delete(betResult);
        }

        public IList<BetResult> GetAll()
        {
            return _repository.GetAllIncluding(x=>x.Bet.Match.League,x=>x.Bet.Match.HomeTeam,x=>x.Bet.Match.AwayTeam,x => x.Bet.User).ToList();
        }

        public IList<BetResult> GetAllUserBets()
        {
            return _repository.GetAllIncluding(x => x.Bet.Match.League, x => x.Bet.Match.HomeTeam, x => x.Bet.Match.AwayTeam, x => x.Bet.User).Where(x => x.Bet.User.Id == AbpSession.UserId).ToList();
        }

        public async Task<IList<BetResult>> GetAllBetResultsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<BetResult> GetBetResultbyBetId(Guid id)
        {
            return _repository.GetAllIncluding(x => x.Bet.Match.League, x => x.Bet.Match.HomeTeam, x => x.Bet.Match.AwayTeam, x => x.Bet.User).FirstOrDefault(x => x.Bet.Id == id);
        }

        public async Task<BetResult> GetbyId(Guid id)
        {
            return _repository.GetAllIncluding(x => x.Bet.Match.League, x => x.Bet.Match.HomeTeam, x => x.Bet.Match.AwayTeam, x => x.Bet.User).FirstOrDefault(x => x.Id == id);
        }

        public async Task<BetResult> Insert(BetResult betResult)
        {
            return await _repository.InsertAsync(betResult);
        }

        public async Task<BetResult> Update(BetResult betResult)
        {
            return await _repository.InsertOrUpdateAsync(betResult);
        }
    }
}
