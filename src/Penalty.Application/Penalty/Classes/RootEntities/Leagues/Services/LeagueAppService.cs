using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using Penalty.Authorization;
using Penalty.Penalty.Indexes.LeagueTypes.Dto;
using Penalty.Penalty.Indexes.LeagueTypes;
using Penalty.Penalty.Indexes.LeagueTypes.Services;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Services
{
    public class LeagueAppService : PenaltyAppServiceBase, ILeagueAppService
    {
        private readonly ILeagueDomainService _leagueDomainService;
        private readonly ILeagueTypeDomainService _leagueTypeDomainService;

        public LeagueAppService(ILeagueDomainService leagueDomainService, ILeagueTypeDomainService leagueTypeDomainService)
        {
            _leagueDomainService = leagueDomainService;
            _leagueTypeDomainService = leagueTypeDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(Guid id)
        {
            _leagueDomainService.Delete(id);
        }

        public IList<LeagueTypeDto> GetLeagueTypeLookup()
        {
            var leagueTypes = _leagueTypeDomainService.GetAll();
            var newLeagueTypes = new List<LeagueTypeDto>();
            ObjectMapper.Map<IList<LeagueType>, List<LeagueTypeDto>>(leagueTypes, newLeagueTypes);

            return newLeagueTypes;
        }


        public IList<LeagueDto> GetAll()
        {
            var leagues = _leagueDomainService.GetAll();
            return ObjectMapper.Map<List<LeagueDto>>(leagues);
        }

        public async Task<IList<LeagueDto>> GetAllLeaguesAsync()
        {
            var leagues = await _leagueDomainService.GetAllLeaguesAsync();
            return ObjectMapper.Map<List<LeagueDto>>(leagues);
        }

        public async Task<LeagueDto> GetbyId(Guid id)
        {
            var league = await _leagueDomainService.GetbyId(id);
            return ObjectMapper.Map<LeagueDto>(league);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateLeagueDto> Insert(CreateLeagueDto leagueDto)
        {
            var league = ObjectMapper.Map<League>(leagueDto);
            var createdLeague = await _leagueDomainService.Insert(league);
            return ObjectMapper.Map<CreateLeagueDto>(createdLeague);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateLeagueDto> Update(UpdateLeagueDto leagueDto)
        {
            var league = await _leagueDomainService.GetbyId(leagueDto.Id);
            ObjectMapper.Map<UpdateLeagueDto, League>(leagueDto, league);
            var updatedLeague = await _leagueDomainService.Update(league);
            return ObjectMapper.Map<UpdateLeagueDto>(updatedLeague);
        }
    }
}
