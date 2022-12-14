using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PayMethods.Dto
{
    public class PayMethodDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public bool isActive { get; set; }
        public string AccountNumber { get; set; }
    }
}
