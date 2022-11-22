using Abp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Penalty.Authorization;
using Penalty.Penalty.Classes.RootEntities.GeneralSetting.Dto;
using Penalty.Penalty.Classes.RootEntities.GeneralSetting.Services;
using Penalty.Penalty.Classes.RootEntities.Teams.Services;
using Penalty.Penalty.ODDSApiMatches.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSetting.Services
{
    public class GeneralSettingAppService : PenaltyAppServiceBase, IGeneralSettingAppService
    {
        private readonly IGeneralSettingDomainService _generalSettingDomainService;
        private readonly IODDSApiDomainService _ODDSApiDomainService;


        public GeneralSettingAppService(IGeneralSettingDomainService generalSettingDomainService, IODDSApiDomainService oDDSApiDomainService)
        {
            _generalSettingDomainService = generalSettingDomainService;
            _ODDSApiDomainService = oDDSApiDomainService;
        }

        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(Guid id)
        {
            _generalSettingDomainService.Delete(id);
        }
        public IList<GeneralSettingDto> GetAll()
        {
            var generalSettings = _generalSettingDomainService.GetAll();
            return ObjectMapper.Map<List<GeneralSettingDto>>(generalSettings);
        }
        [HttpGet]
        public async Task BackGroundWorker() => await _ODDSApiDomainService.GetAll();
        public async Task<IList<GeneralSettingDto>> GetAllGeneralSettingsAsync()
        {
            var generalSettings = _generalSettingDomainService.GetAllGeneralSettingsAsync();
            return ObjectMapper.Map<List<GeneralSettingDto>>(generalSettings);
        }

        public async Task<GeneralSettingDto> GetbyId(Guid id)
        {
            var generalSetting = await _generalSettingDomainService.GetbyId(id);
            return ObjectMapper.Map<GeneralSettingDto>(generalSetting);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateGeneralSettingDto> Insert(CreateGeneralSettingDto generalSettingdto)
        {
            var generalSetting = ObjectMapper.Map<GeneralSettings>(generalSettingdto);
            var createdGeneralSetting = await _generalSettingDomainService.Insert(generalSetting);
            return ObjectMapper.Map<CreateGeneralSettingDto>(createdGeneralSetting);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateGeneralSettingDto> Update(UpdateGeneralSettingDto generalSettingdto)
        {
            var generalSetting = await _generalSettingDomainService.GetbyId(generalSettingdto.Id);
            ObjectMapper.Map<UpdateGeneralSettingDto, GeneralSettings>(generalSettingdto, generalSetting);
            var updatedGeneralSetting = await _generalSettingDomainService.Update(generalSetting);
            return ObjectMapper.Map<UpdateGeneralSettingDto>(updatedGeneralSetting);
        }
    }
}
