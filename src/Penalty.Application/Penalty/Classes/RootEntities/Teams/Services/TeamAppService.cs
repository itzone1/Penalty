using Abp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Penalty.Authorization;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.ODDSApiMatches.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Services
{
    public class TeamAppService : PenaltyAppServiceBase, ITeamAppService
    {
        private readonly ITeamDomainService _teamDomainService;
        private readonly IODDSApiDomainService _ODDSApiDomainService;


        public TeamAppService(ITeamDomainService teamDomainService, IODDSApiDomainService oDDSApiDomainService)
        {
            _teamDomainService = teamDomainService;
            _ODDSApiDomainService = oDDSApiDomainService;
        }

        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(TeamDto teamdto)
        {
            var team = ObjectMapper.Map<Team>(teamdto);
            _teamDomainService.Delete(team);
        }
        public IList<TeamDto> GetAll()
        {
            var teams = _teamDomainService.GetAll();
            return ObjectMapper.Map<List<TeamDto>>(teams);
        }
        [HttpGet]
        public async Task BackGroundWorker() => await _ODDSApiDomainService.GetAll();
        public async Task<IList<TeamDto>> GetAllTeamsAsync()
        {
            var teams = _teamDomainService.GetAllTeamsAsync();
            return ObjectMapper.Map<List<TeamDto>>(teams);
        }

        public async Task<TeamDto> GetbyId(Guid id)
        {
            var team = await _teamDomainService.GetbyId(id);
            return ObjectMapper.Map<TeamDto>(team);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateTeamDto> Insert(CreateTeamDto teamdto)
        {
            var team = ObjectMapper.Map<Team>(teamdto);
            var createdTeam = await _teamDomainService.Insert(team);
            return ObjectMapper.Map<CreateTeamDto>(createdTeam);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateTeamDto> Update(UpdateTeamDto teamdto)
        {
            var team = await _teamDomainService.GetbyId(teamdto.Id);
            ObjectMapper.Map<UpdateTeamDto, Team>(teamdto, team);
            var updatedTeam = await _teamDomainService.Update(team);
            return ObjectMapper.Map<UpdateTeamDto>(updatedTeam);
        }
    }
}
