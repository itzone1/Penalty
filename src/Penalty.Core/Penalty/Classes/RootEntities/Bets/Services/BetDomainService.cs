using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Penalty.Authorization.Users;
using Penalty.Penalty.InvitedUsers;
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
        private readonly UserManager _userManager;
        private readonly IRepository<GeneralSettings,Guid> _generalSettingsRepository;
        private IAbpSession AbpSession { get; set; }
        private readonly IRepository<InvitedUser, Guid> _InvitedUsersRepository;

        public BetDomainService(IRepository<Bet, Guid> repository, UserManager userManager, IAbpSession abpSession, IRepository<PaySystem, Guid> paySystemRepository, IRepository<GeneralSettings, Guid> generalSettingsRepository, IRepository<InvitedUser, Guid> invitedUsersRepository)
        {
            _repository = repository;
            _userManager = userManager;
            AbpSession = abpSession;
            _paySystemRepository = paySystemRepository;
            _generalSettingsRepository = generalSettingsRepository;
            _InvitedUsersRepository = invitedUsersRepository;
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
            var currentUser = _userManager.GetUserById((long)AbpSession.UserId);
            var isInvited = _InvitedUsersRepository.GetAllIncluding(x => x.User).FirstOrDefault(x => x.UserId == currentUser.Id && x.isActivated == false) ;
            if (isInvited != null)
            {
                isInvited.isActivated = true;
                await _InvitedUsersRepository.UpdateAsync(isInvited);
            }
            bet.BettingDate = DateTime.Now;
            bet.BetStatus = Enums.BetStatus.Pending;
            if (AbpSession.UserId != null)
            {
                bet.User = _userManager.GetUserById((long)AbpSession.UserId);
            }

            PaySystem paySystem = new PaySystem()
            {
                MerchantUrl = _generalSettingsRepository.GetAll().FirstOrDefault().MerchantUrl,
                m_shop = _generalSettingsRepository.GetAll().FirstOrDefault().MerchantShop,
                m_key = _generalSettingsRepository.GetAll().FirstOrDefault().MerchantSecretKey,
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
