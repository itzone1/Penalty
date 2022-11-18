using Penalty.Penalty.Indexes.Clubs.Dto;
using Penalty.Penalty.Indexes.Clubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Penalty.Penalty.Indexes.Countries.Dto;

namespace Penalty.Penalty.Indexes.Countries.Map
{
    public class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<Country, CountryDto>();
            CreateMap<Country, CreateCountryDto>();
            CreateMap<Country, UpdateCountryDto>();
            CreateMap<CountryDto, Country>();
            CreateMap<CreateCountryDto, Country>();
            CreateMap<UpdateCountryDto, Country>();
        }
    }
}
