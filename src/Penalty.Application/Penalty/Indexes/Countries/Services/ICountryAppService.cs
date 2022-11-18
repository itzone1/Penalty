using Abp.Application.Services;
using Penalty.Penalty.Indexes.Clubs.Dto;
using Penalty.Penalty.Indexes.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Countries.Services
{
    public interface ICountryAppService : IApplicationService
    {
        IList<CountryDto> GetAll();
        Task<IList<CountryDto>> GetAllCountriesAsync();
        Task<CountryDto> GetbyId(Guid id);
        Task<CreateCountryDto> Insert(CreateCountryDto countryDto);
        Task<UpdateCountryDto> Update(UpdateCountryDto countryDto);
        void Delete(CountryDto countryDto);
    }
}
