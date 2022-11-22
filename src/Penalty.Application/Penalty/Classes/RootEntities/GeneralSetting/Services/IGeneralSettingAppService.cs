using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Services
{
    public interface IGeneralSettingAppService : IApplicationService
    {
        IList<GeneralSettingDto> GetAll();
        Task<IList<GeneralSettingDto>> GetAllTeamsAsync();
        Task<GeneralSettingDto> GetbyId(Guid id);
        Task<CreateGeneralSettingDto> Insert(CreateGeneralSettingDto teamdto);
        Task<UpdateGeneralSettingDto> Update(UpdateGeneralSettingDto teamdto);
        void Delete(Guid id);
        [HttpGet]
        Task BackGroundWorker();
    }
}
