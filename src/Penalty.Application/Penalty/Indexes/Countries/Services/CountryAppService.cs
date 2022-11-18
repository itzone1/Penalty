using Abp.Authorization;
using Penalty.Authorization;
using Penalty.Penalty.Indexes.Clubs;
using Penalty.Penalty.Indexes.Clubs.Dto;
using Penalty.Penalty.Indexes.Clubs.Services;
using Penalty.Penalty.Indexes.Countries.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Countries.Services
{
    public class CountryAppService : PenaltyAppServiceBase, ICountryAppService
    {
        private readonly ICountryDomainService _countryDomainService;

        public CountryAppService(ICountryDomainService countryDomainService)
        {
            _countryDomainService = countryDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(CountryDto countryDto)
        {
            var country = ObjectMapper.Map<Country>(countryDto);
            _countryDomainService.Delete(country);
        }

        public IList<CountryDto> GetAll()
        {
            var countries = _countryDomainService.GetAll();
            return ObjectMapper.Map<List<CountryDto>>(countries);
        }

        public async Task<IList<CountryDto>> GetAllCountriesAsync()
        {
            var countries = await _countryDomainService.GetAllCountriesAsync();
            return ObjectMapper.Map<List<CountryDto>>(countries);
        }

        public async Task<CountryDto> GetbyId(Guid id)
        {
            var country = await _countryDomainService.GetbyId(id);
            return ObjectMapper.Map<CountryDto>(country);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateCountryDto> Insert(CreateCountryDto countryDto)
        {
            var country = ObjectMapper.Map<Country>(countryDto);
            var createdCountry = await _countryDomainService.Insert(country);
            return ObjectMapper.Map<CreateCountryDto>(createdCountry);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateCountryDto> Update(UpdateCountryDto countryDto)
        {
            var country = await _countryDomainService.GetbyId(countryDto.Id);
            ObjectMapper.Map<UpdateCountryDto, Country>(countryDto, country);
            var updatedCountry = await _countryDomainService.Update(country);
            return ObjectMapper.Map<UpdateCountryDto>(updatedCountry);
        }
    }
}
