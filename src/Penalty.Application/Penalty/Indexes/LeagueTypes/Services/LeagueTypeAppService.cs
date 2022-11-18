using Penalty.Penalty.Indexes.Countries.Dto;
using Penalty.Penalty.Indexes.Countries;
using Penalty.Penalty.Indexes.LeagueTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Penalty.Authorization;

namespace Penalty.Penalty.Indexes.LeagueTypes.Services
{
    public class LeagueTypeAppService : PenaltyAppServiceBase, ILeagueTypeAppService
    {
        private readonly ILeagueTypeDomainService _leagueTypeDomainService;

        public LeagueTypeAppService(ILeagueTypeDomainService leagueTypeDomainService)
        {
            _leagueTypeDomainService = leagueTypeDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(LeagueTypeDto leagueTypeDto)
        {
            var leagueType = ObjectMapper.Map<LeagueType>(leagueTypeDto);
            _leagueTypeDomainService.Delete(leagueType);
        }

        public IList<LeagueTypeDto> GetAll()
        {
            var leagueTypes = _leagueTypeDomainService.GetAll();
            return ObjectMapper.Map<List<LeagueTypeDto>>(leagueTypes);
        }

        public async Task<IList<LeagueTypeDto>> GetAllLeagueTypesAsync()
        {
            var leagueTypes = await _leagueTypeDomainService.GetAllLeaguesAsync();
            return ObjectMapper.Map<List<LeagueTypeDto>>(leagueTypes);
        }

        public async Task<LeagueTypeDto> GetbyId(Guid id)
        {
            var leagueType = await _leagueTypeDomainService.GetbyId(id);
            return ObjectMapper.Map<LeagueTypeDto>(leagueType);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateLeagueTypeDto> Insert(CreateLeagueTypeDto leagueTypeDto)
        {
            var leagueType = ObjectMapper.Map<LeagueType>(leagueTypeDto);
            var createdLeagueType = await _leagueTypeDomainService.Insert(leagueType);
            return ObjectMapper.Map<CreateLeagueTypeDto>(createdLeagueType);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateLeagueTypeDto> Update(UpdateLeagueTypeDto leagueTypeDto)
        {
            var leagueType = await _leagueTypeDomainService.GetbyId(leagueTypeDto.Id);
            ObjectMapper.Map<UpdateLeagueTypeDto, LeagueType>(leagueTypeDto, leagueType);
            var updatedLeagueType = await _leagueTypeDomainService.Update(leagueType);
            return ObjectMapper.Map<UpdateLeagueTypeDto>(updatedLeagueType);
        }
    }
}
