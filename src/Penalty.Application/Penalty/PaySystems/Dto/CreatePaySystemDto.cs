using Abp.Application.Services.Dto;
using Penalty.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PaySystems.Dto
{
    public class CreatePaySystemDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public double m_amount { get; set; }
        public string m_curr { get; set; }
        public string? m_desc { get; set; }
    }
}
