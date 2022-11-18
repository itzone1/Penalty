using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.LeagueTypes.Services
{
    public class LeagueTypeDomainService : ILeagueTypeDomainService
    {
        private readonly IRepository<LeagueType,Guid> _repository;

        public LeagueTypeDomainService(IRepository<LeagueType, Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(LeagueType leagueType)
        {
           _repository.Delete(leagueType);
        }

        public IList<LeagueType> GetAll()
        {
          return _repository.GetAll().ToList();
        }

        public async Task<IList<LeagueType>> GetAllLeaguesAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<LeagueType> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<LeagueType> Insert(LeagueType leagueType)
        {
            return await _repository.InsertAsync(leagueType);
        }

        public async Task<LeagueType> Update(LeagueType leagueType)
        {
            return await _repository.InsertOrUpdateAsync(leagueType);
        }
    }
}
