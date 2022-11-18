using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Penalty.Authorization.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Services
{
    public class BetDomainService : IBetDomainService
    {
        private readonly IRepository<Bet, Guid> _repository;
        private readonly UserManager _userManager;
        private IAbpSession AbpSession { get; set; }

        public BetDomainService(IRepository<Bet, Guid> repository,UserManager userManager,IAbpSession abpSession)
        {
            _repository = repository;
            _userManager = userManager;
            AbpSession = abpSession;
        }

        public void Delete(Bet bet)
        {
          _repository.Delete(bet);
        }

        public IList<Bet> GetAll()
        {
            return _repository.GetAllIncluding(x=>x.Match,x=> x.Match.League,x=> x.Match.HomeTeam,x=>x.Match.AwayTeam,x=>x.PayMethod,x=>x.User).ToList();
        }

        public async Task<IList<Bet>> GetAllBetsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<Bet> GetbyId(Guid id)
        {
            return _repository.GetAllIncluding(x => x.Match, x => x.Match.League, x => x.Match.HomeTeam, x => x.Match.AwayTeam, x => x.PayMethod, x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Bet> Insert(Bet bet)
        {
            bet.BettingDate = DateTime.Now;
            bet.BetStatus = Enums.BetStatus.Pending;
            if (AbpSession.UserId != null)
            {
                bet.User = _userManager.GetUserById((long)AbpSession.UserId);
            }
            return await _repository.InsertAsync(bet);
        }

        public async Task<Bet> Update(Bet bet)
        {
            if (bet.Match.MatchStatus != Enums.MatchStatus.NotStarted)
            {
                return null;
            }
            return await _repository.InsertOrUpdateAsync(bet);
        }

        public  IList<Bet> GetUserBets()
        {
            return _repository.GetAllIncluding(x => x.Match.League, x => x.Match.HomeTeam, x => x.Match.AwayTeam).Where(x => x.User.Id == AbpSession.UserId).ToList();
        }
    }
}
