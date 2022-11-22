using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSetting.Services
{
    public interface IGeneralSettingDomainService : IDomainService
    {
        IList<GeneralSettings> GetAll();
        Task<IList<GeneralSettings>> GetAllGeneralSettingsAsync();
        Task<GeneralSettings> GetbyId(Guid id);
        Task<GeneralSettings> Insert(GeneralSettings team);
        Task<GeneralSettings> Update(GeneralSettings team);
        void Delete(Guid id);
    }
}
