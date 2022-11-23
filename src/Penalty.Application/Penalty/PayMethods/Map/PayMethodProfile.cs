using AutoMapper;
using Penalty.Penalty.PayMethods.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PayMethods.Map
{
    public class PayMethodProfile : Profile
    {
        public PayMethodProfile()
        {
            CreateMap<PayMethod,PayMethodDto>();
            CreateMap<PayMethodDto, PayMethod>();
        }
    }
}
