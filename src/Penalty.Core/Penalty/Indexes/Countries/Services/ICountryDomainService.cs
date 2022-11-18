using Abp.Domain.Services;
using Penalty.Penalty.Indexes.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Countries.Services
{
    public interface ICountryDomainService : IDomainService
    {
        IList<Country> GetAll();
        Task<IList<Country>> GetAllCountriesAsync();
        Task<Country> GetbyId(Guid id);
        Task<Country> Insert(Country country);
        Task<Country> Update(Country country);
        void Delete(Country country);
    }
}
