using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Penalty.Authorization.Users;
using Penalty.Penalty.PaySystems;
using Penalty.Penalty.PaySystems.Services;
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
        private readonly IRepository<PaySystem, Guid> _paySystemRepository;
        private readonly PaySystemDomainService _paySystemDomainService;
        private readonly UserManager _userManager;
        private readonly GeneralSettings _generalSettings;
        private IAbpSession AbpSession { get; set; }

        public BetDomainService(IRepository<Bet, Guid> repository, UserManager userManager, IAbpSession abpSession, IRepository<PaySystem, Guid> paySystemRepository, PaySystemDomainService paySystemDomainService, GeneralSettings generalSettings)
        {
            _repository = repository;
            _userManager = userManager;
            AbpSession = abpSession;
            _paySystemRepository = paySystemRepository;
            _paySystemDomainService = paySystemDomainService;
            _generalSettings = generalSettings;
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

            PaySystem paySystem = new PaySystem()
            {
                MerchantUrl = _generalSettings.MerchantUrl,
                m_shop = _generalSettings.MerchantShop,
                m_key = _generalSettings.MerchantSecretKey,
                m_amount = bet.BetBalance,
                m_curr = "USD",
                m_desc = "",
                m_orderid = 12345
            };

            await _paySystemRepository.InsertAsync(paySystem);
            bet.PaySystemId = paySystem.Id;
            bet.PaySystem = paySystem;

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
