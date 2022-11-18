using Abp.Domain.Repositories;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Clubs.Services
{
    public class ClubDomainService : IClubDomainService
    {
        private readonly IRepository<Club, Guid> _repository;

        public ClubDomainService(IRepository<Club, Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(Club club)
        {
            _repository.Delete(club);
        }

        public IList<Club> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<IList<Club>> GetAllClubsAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<Club> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Club> Insert(Club club)
        {
            return await _repository.InsertAsync(club);
        }

        public async Task<Club> Update(Club club)
        {
            return await _repository.InsertOrUpdateAsync(club);
        }
    }
}
