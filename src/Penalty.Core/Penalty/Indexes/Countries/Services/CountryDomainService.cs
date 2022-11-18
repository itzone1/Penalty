using Abp.Domain.Repositories;
using Nito.AsyncEx;
using Penalty.Penalty.Indexes.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Countries.Services
{
    public class CountryDomainService : ICountryDomainService
    {
        private readonly IRepository<Country, Guid> _repository;

        public CountryDomainService(IRepository<Country, Guid> repository)
        {
            _repository = repository;
        }

        public void Delete(Country country)
        {
           _repository.Delete(country);
        }

        public IList<Country> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public async Task<IList<Country>> GetAllCountriesAsync()
        {
            return await _repository.GetAllListAsync();
        }

        public async Task<Country> GetbyId(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Country> Insert(Country country)
        {
            return await _repository.InsertAsync(country);
        }

        public async Task<Country> Update(Country country)
        {
            return await _repository.InsertOrUpdateAsync(country);
        }
    }
}
