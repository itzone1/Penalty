using Penalty.Penalty.Classes.Entities.Matches.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Abp.Authorization;
using Penalty.Authorization;

namespace Penalty.Penalty.Classes.Entities.Matches.Services
{
    public class MatchAppService : PenaltyAppServiceBase, IMatchAppService
    {
        private readonly IMatchDomainService _matchDomainService;

        public MatchAppService(IMatchDomainService matchDomainService)
        {
            _matchDomainService = matchDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(MatchDto matchdto)
        {
            var match = ObjectMapper.Map<Match>(matchdto);
            _matchDomainService.Delete(match);
        }
        public IList<MatchDto> GetAll()
        {
            var matches = _matchDomainService.GetAll();
            return ObjectMapper.Map<List<MatchDto>>(matches);
        }

        public IList<MatchDto> GetAllFinishedMatches()
        {
            var matches = _matchDomainService.GetAllFinishedMatches();
            return ObjectMapper.Map<List<MatchDto>>(matches);
        }

        public async Task<IList<MatchDto>> GetAllMatchesAsync()
        {
            var matches = await _matchDomainService.GetAllMatchesAsync();
            return ObjectMapper.Map<List<MatchDto>>(matches);
        }

        public IList<MatchDto> GetAllNotStartedMatches()
        {
            var matches = _matchDomainService.GetAllNotStartedMatches();
            return ObjectMapper.Map<List<MatchDto>>(matches);
        }

        public IList<MatchDto> GetAllPendingMatches()
        {
            var matches = _matchDomainService.GetAllPendingMatches();
            return ObjectMapper.Map<List<MatchDto>>(matches);
        }

        public async Task<MatchDto> GetbyId(Guid id)
        {
            var match = await _matchDomainService.GetbyId(id);
            return ObjectMapper.Map<MatchDto>(match);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateMatchDto> Insert(CreateMatchDto matchdto)
        {
            var match = ObjectMapper.Map<Match>(matchdto);
            var createdMatch = await _matchDomainService.Insert(match);
            return ObjectMapper.Map<CreateMatchDto>(createdMatch);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateMatchDto> Update(UpdateMatchDto matchdto)
        {
            var match = await _matchDomainService.GetbyId(matchdto.Id);
            ObjectMapper.Map<UpdateMatchDto, Match>(matchdto, match);
            var updatedMatch = await _matchDomainService.Update(match);
            return ObjectMapper.Map<UpdateMatchDto>(updatedMatch);
        }
    }
}
