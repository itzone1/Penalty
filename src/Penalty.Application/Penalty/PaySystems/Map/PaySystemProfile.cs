using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penalty.Penalty.PaySystems.Dto;

namespace Penalty.Penalty.PaySystems.Map
{
    public class PaySystemProfile : Profile
    {
        public PaySystemProfile()
        {
            CreateMap<PaySystem, PaySystemDto>();
            CreateMap<PaySystemDto, PaySystem>();
            CreateMap<CreatePaySystemDto, PaySystem>();
            CreateMap<PaySystem, CreatePaySystemDto>();
        }
    }
}
