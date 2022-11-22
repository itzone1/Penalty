using Abp.Domain.Repositories;
using Penalty.Penalty.Indexes.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Services
{
    public class TeamDomainService : ITeamDomainService
    {
        private readonly IRepository<Team,Guid> _repository;

        public TeamDomainService(IRepository<Team,Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(Guid id)     
        {
           _repository.Delete(id);
        }

        public IList<Team> GetAll()
        {
            return _repository.GetAllIncluding(x=> x.Club ,x=> x.Country).ToList();
        }

        public async Task<IList<Team>> GetAllTeamsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<Team> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Team> Insert(Team team)
        {
            return await _repository.InsertAsync(team);
        }

        public async Task<Team> Update(Team newteam)
        {
            return await _repository.InsertOrUpdateAsync(newteam);
        }
    }
}
