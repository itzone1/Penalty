using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Penalty.Penalty.Classes.RootEntities.GeneralSetting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSetting.Services
{
    public interface IGeneralSettingAppService : IApplicationService
    {
        IList<GeneralSettingDto> GetAll();
        Task<IList<GeneralSettingDto>> GetAllGeneralSettingsAsync();
        Task<GeneralSettingDto> GetbyId(Guid id);
        Task<CreateGeneralSettingDto> Insert(CreateGeneralSettingDto generalSettingdto);
        Task<UpdateGeneralSettingDto> Update(UpdateGeneralSettingDto generalSettingdto);
        void Delete(Guid id);
        [HttpGet]
        Task BackGroundWorker();
    }
}
