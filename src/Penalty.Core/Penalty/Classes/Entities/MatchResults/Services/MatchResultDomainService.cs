using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Penalty.Authorization.Users;
using Penalty.Penalty.Classes.Entities.BetResults;
using Penalty.Penalty.Classes.Entities.BetResults.Services;
using Penalty.Penalty.Classes.Entities.Matches;
using Penalty.Penalty.Classes.Entities.Matches.Services;
using Penalty.Penalty.Classes.RootEntities;
using Penalty.Penalty.Classes.RootEntities.Bets.Services;
using Penalty.Penalty.InvitedUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Services
{
    public class MatchResultDomainService : IMatchResultDomainService
    {
        private readonly IRepository<MatchResult, Guid> _repository;
        private readonly BetDomainService _betDomainService;
        private readonly BetResultDomainService _betResultDomainService;
        private readonly MatchDomainService _matchDomainService;

        private readonly IRepository<GeneralSettings, Guid> _GeneralSettingsrepository;
        private readonly IRepository<InvitedUser, Guid> _InvitedRepository;
        private IAbpSession abpSession;
        private readonly UserManager _userManager;

        public MatchResultDomainService(
            IRepository<MatchResult, Guid> repository,
            BetDomainService betDomainService,
            BetResultDomainService betResultDomainService,
            MatchDomainService matchDomainService, 
            IRepository<GeneralSettings,Guid> generalSettingsrepository,
            IRepository<InvitedUser, Guid> invitedRepository,
            IAbpSession abpSession,
            UserManager userManager
            )
        {
            _repository = repository;
            _betDomainService = betDomainService;
            _betResultDomainService = betResultDomainService;
            _matchDomainService = matchDomainService;
            _GeneralSettingsrepository = generalSettingsrepository;
            _InvitedRepository = invitedRepository;
            this.abpSession = abpSession;
            _userManager = userManager;
        }

        public void Delete(MatchResult matchResult)
        {
           _repository.Delete(matchResult);
        }

        public IList<MatchResult> GetAll()
        {
            return _repository.GetAllIncluding(x => x.Match.League, x => x.Match.HomeTeam, x => x.Match.AwayTeam).ToList();
        }

        public async Task<IList<MatchResult>> GetAllMatchResultsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<MatchResult> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<MatchResult> Insert(MatchResult matchResult)
        {
            var currentMatch = await _matchDomainService.GetbyId(matchResult.MatchId);
            currentMatch.MatchStatus = Enums.MatchStatus.Finished;
            await _matchDomainService.Update(currentMatch);
            AddBetsResults(matchResult);
            var currentDate = DateTime.Now;
            matchResult.MatchEndingDate = currentDate;
            matchResult.MatchEndingTime = currentDate;
            return await _repository.InsertAsync(matchResult);
        }

        public async Task<MatchResult> Update(MatchResult matchResult)
        {
            return await _repository.InsertOrUpdateAsync(matchResult);
        }


        private async void AddBetsResults(MatchResult matchResult)
        {
            var bets = _betDomainService.GetAll().Where(x=> x.Match.Id == matchResult.MatchId);
            foreach(var bet in bets)
            {
                bool isWon = true;
                if(bet.HomeTeamScore != matchResult.HomeTeamScore)
                {
                    isWon = false;
                }
                else if(bet.AwayTeamScore != matchResult.AwayTeamScore)
                {
                    isWon = false;
                }
                BetResult betResult = new BetResult();
                betResult.Bet = bet;
                betResult.BetId = bet.Id;
                betResult.MatchResult = matchResult;
                betResult.MatchResultId = matchResult.Id;
                betResult.DeservedBalance = bet.BetBalance *  GetDeservableODD(matchResult.Match);
                if(isWon)
                {
                    betResult.Result = Enums.Result.WonBet;
                }
                else
                {
                    betResult.Result = Enums.Result.LostBet;
                }
                bet.BetStatus = Enums.BetStatus.Finished;
                await _betDomainService.Update(bet);
                await _betResultDomainService.Insert(betResult);
            }

        }
        private double GetDeservableODD(Match match)
        {
            double newODD = 0;
            var ODDsettings = _GeneralSettingsrepository.GetAll().Select(x => x.DefaultODD).FirstOrDefault();
            int numberOfInvitedUsers = _InvitedRepository.GetAllIncluding(x => x.User).Where(x => x.InvitedByUserId == (long)abpSession.UserId).Count();
            newODD = match.ODD + (ODDsettings * numberOfInvitedUsers);
            return newODD;
        }
    }
}
