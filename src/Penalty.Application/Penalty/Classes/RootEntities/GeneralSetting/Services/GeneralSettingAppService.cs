using Abp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Penalty.Authorization;
using Penalty.Penalty.Classes.RootEntities.GeneralSetting.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Services;
using Penalty.Penalty.ODDSApiMatches.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSettings.Services
{
    public class GeneralSettingAppService : PenaltyAppServiceBase, IGeneralSettingAppService
    {
        private readonly IGeneralSettingDomainService _teamDomainService;
        private readonly IODDSApiDomainService _ODDSApiDomainService;


        public GeneralSettingAppService(IGeneralSettingDomainService teamDomainService, IODDSApiDomainService oDDSApiDomainService)
        {
            _teamDomainService = teamDomainService;
            _ODDSApiDomainService = oDDSApiDomainService;
        }

        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(Guid id)
        {
            _teamDomainService.Delete(id);
        }
        public IList<GeneralSettingDto> GetAll()
        {
            var teams = _teamDomainService.GetAll();
            return ObjectMapper.Map<List<GeneralSettingDto>>(teams);
        }
        [HttpGet]
        public async Task BackGroundWorker() => await _ODDSApiDomainService.GetAll();
        public async Task<IList<GeneralSettingDto>> GetAllGeneralSettingsAsync()
        {
            var teams = _teamDomainService.GetAllGeneralSettingsAsync();
            return ObjectMapper.Map<List<GeneralSettingDto>>(teams);
        }

        public async Task<GeneralSettingDto> GetbyId(Guid id)
        {
            var team = await _teamDomainService.GetbyId(id);
            return ObjectMapper.Map<GeneralSettingDto>(team);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateGeneralSettingDto> Insert(CreateGeneralSettingDto teamdto)
        {
            var team = ObjectMapper.Map<GeneralSettings>(teamdto);
            var createdGeneralSetting = await _teamDomainService.Insert(team);
            return ObjectMapper.Map<CreateGeneralSettingDto>(createdGeneralSetting);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateGeneralSettingDto> Update(UpdateGeneralSettingDto teamdto)
        {
            var team = await _teamDomainService.GetbyId(teamdto.Id);
            ObjectMapper.Map<UpdateGeneralSettingDto, GeneralSettings>(teamdto, team);
            var updatedGeneralSetting = await _teamDomainService.Update(team);
            return ObjectMapper.Map<UpdateGeneralSettingDto>(updatedGeneralSetting);
        }
    }
}
