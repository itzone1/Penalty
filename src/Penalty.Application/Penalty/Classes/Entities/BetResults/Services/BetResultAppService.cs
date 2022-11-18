using Penalty.Penalty.Classes.Entities.BetResult.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Penalty.Authorization;

namespace Penalty.Penalty.Classes.Entities.BetResults.Services
{
    public class BetResultAppService : PenaltyAppServiceBase, IBetResultAppService
    {
        private readonly BetResultDomainService _betResultDomainService;

        public BetResultAppService(BetResultDomainService betResultDomainService)
        {
            _betResultDomainService = betResultDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(BetResultDto betResultDto)
        {
            var betresult = ObjectMapper.Map<BetResult>(betResultDto);
            _betResultDomainService.Delete(betresult);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public IList<BetResultDto> GetAll()
        {
            var betresults = _betResultDomainService.GetAll();
            return ObjectMapper.Map<List<BetResultDto>>(betresults);
        }
        public IList<BetResultDto> GetAllUserBets()
        {
            var betresults = _betResultDomainService.GetAllUserBets();
            return ObjectMapper.Map<List<BetResultDto>>(betresults);
        }

        public async Task<IList<BetResultDto>> GetAllBetResultsAsync()
        {
            var betresults = await _betResultDomainService.GetAllBetResultsAsync();
            return ObjectMapper.Map<List<BetResultDto>>(betresults);
        }

        public async Task<BetResultDto> GetBetResultbyBetId(Guid id)
        {
            var betresults = await _betResultDomainService.GetBetResultbyBetId(id);
            return ObjectMapper.Map<BetResultDto>(betresults);
        }

        public async Task<BetResultDto> GetbyId(Guid id)
        {
            var betresults = await _betResultDomainService.GetbyId(id);
            return ObjectMapper.Map<BetResultDto>(betresults);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateBetResultDto> Insert(CreateBetResultDto betResultDto)
        {
            var betresult = ObjectMapper.Map<BetResult>(betResultDto);
            var createdBetResult = await _betResultDomainService.Insert(betresult);
            return ObjectMapper.Map<CreateBetResultDto>(createdBetResult);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateBetResultDto> Update(UpdateBetResultDto betResultDto)
        {
            var betresult = await _betResultDomainService.GetbyId(betResultDto.Id);
            ObjectMapper.Map<UpdateBetResultDto, BetResult>(betResultDto, betresult);
            var updatedBetResult = await _betResultDomainService.Update(betresult);
            return ObjectMapper.Map<UpdateBetResultDto>(updatedBetResult);
        }
    }
}
