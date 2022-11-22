using Abp.Domain.Repositories;
using Penalty.Penalty.Indexes.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSetting.Services
{
    public class GeneralSettingDomainService : IGeneralSettingDomainService
    {
        private readonly IRepository<GeneralSettings,Guid> _repository;

        public GeneralSettingDomainService(IRepository<GeneralSettings,Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)     
        {
           _repository.Delete(id);
        }

        public IList<GeneralSettings> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<IList<GeneralSettings>> GetAllGeneralSettingsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<GeneralSettings> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<GeneralSettings> Insert(GeneralSettings generalSetting)
        {
            return await _repository.InsertAsync(generalSetting);
        }

        public async Task<GeneralSettings> Update(GeneralSettings newgeneralSetting)
        {
            return await _repository.InsertOrUpdateAsync(newgeneralSetting);
        }
    }
}
