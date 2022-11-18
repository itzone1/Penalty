using Penalty.Penalty.Classes.RootEntities.Bets.Dto;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Penalty.Authorization;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Services
{
    public class BetAppService : PenaltyAppServiceBase, IBetAppService
    {
        private readonly BetDomainService _betDomainService;

        public BetAppService(BetDomainService betDomainService)
        {
            _betDomainService = betDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(BetDto betDto)
        {
            var bet = ObjectMapper.Map<Bet>(betDto);
            _betDomainService.Delete(bet);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public IList<BetDto> GetAll()
        {
            var bets = _betDomainService.GetAll();
            return ObjectMapper.Map<List<BetDto>>(bets);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<IList<BetDto>> GetAllBetsAsync()
        {
            var bets = await _betDomainService.GetAllBetsAsync();
            return ObjectMapper.Map<List<BetDto>>(bets);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<BetDto> GetbyId(Guid id)
        {
            var bet = await _betDomainService.GetbyId(id);
            return ObjectMapper.Map<BetDto>(bet);
        }

        public IList<BetDto> GetUserBets()
        {
            var bets = _betDomainService.GetUserBets();
            return ObjectMapper.Map<List<BetDto>>(bets);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateBetDto> Insert(CreateBetDto betDto)
        {
            var bet = ObjectMapper.Map<Bet>(betDto);
            var createdBet = await _betDomainService.Insert(bet);
            return ObjectMapper.Map<CreateBetDto>(createdBet);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateBetDto> Update(UpdateBetDto betDto)
        {
            var bet = await _betDomainService.GetbyId(betDto.Id);
            ObjectMapper.Map<UpdateBetDto, Bet>(betDto, bet);
            var updatedBet = await _betDomainService.Update(bet);
            return ObjectMapper.Map<UpdateBetDto>(updatedBet);
        }
    }
}
