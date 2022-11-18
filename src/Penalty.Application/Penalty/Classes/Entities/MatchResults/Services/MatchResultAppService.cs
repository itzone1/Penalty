using Abp.Authorization;
using Penalty.Authorization;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Services
{
    [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
    public class MatchResultAppService : PenaltyAppServiceBase, IMatchResultAppService
    {
        private readonly IMatchResultDomainService _matchResultDomainService;

        public MatchResultAppService(IMatchResultDomainService matchResultDomainService)
        {
            _matchResultDomainService = matchResultDomainService;
        }

        public void Delete(MatchResultDto matchresultdto)
        {
            var matchresult = ObjectMapper.Map<MatchResult>(matchresultdto);
            _matchResultDomainService.Delete(matchresult);
        }

        public IList<MatchResultDto> GetAll()
        {
            var matcheresults = _matchResultDomainService.GetAll();
            return ObjectMapper.Map<List<MatchResultDto>>(matcheresults);
        }

        public async Task<IList<MatchResultDto>> GetAllMatchResultsAsync()
        {
            var matcheresults = await _matchResultDomainService.GetAllMatchResultsAsync();
            return  ObjectMapper.Map<List<MatchResultDto>>(matcheresults);
        }

        public async Task<MatchResultDto> GetbyId(Guid id)
        {
            var matchresult = await _matchResultDomainService.GetbyId(id);
            return ObjectMapper.Map<MatchResultDto>(matchresult);
        }

        public async Task<CreateMatchResultDto> Insert(CreateMatchResultDto matchresultdto)
        {
            var matchresult = ObjectMapper.Map<MatchResult>(matchresultdto);
            var createdMatchResult = await _matchResultDomainService.Insert(matchresult);
            return ObjectMapper.Map<CreateMatchResultDto>(createdMatchResult);
        }

        public async Task<UpdateMatchResultDto> Update(UpdateMatchResultDto matchresultdto)
        {
            var matchResult = await _matchResultDomainService.GetbyId(matchresultdto.Id);
            ObjectMapper.Map<UpdateMatchResultDto, MatchResult>(matchresultdto, matchResult);
            var updatedMatchResult = await _matchResultDomainService.Update(matchResult);
            return ObjectMapper.Map<UpdateMatchResultDto>(updatedMatchResult);
        }
    }
}
