using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Services
{
    public class LeagueDomainService : ILeagueDomainService
    {
        private readonly IRepository<League, Guid> _repository;

        public LeagueDomainService(IRepository<League, Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)
        {
           _repository.Delete(id);
        }

        public IList<League> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<IList<League>> GetAllLeaguesAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<League> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<League> Insert(League league)
        {
            return await _repository.InsertAsync(league);
        }

        public async Task<League> Update(League league)
        {
            return await _repository.InsertOrUpdateAsync(league);
        }
    }
}
