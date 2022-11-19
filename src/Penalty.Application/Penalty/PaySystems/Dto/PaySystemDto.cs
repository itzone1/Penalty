using Abp.Application.Services.Dto;
using Penalty.Authorization.Users;
using Penalty.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PaySystems.Dto
{
    public class PaySystemDto : EntityDto<Guid>
    {
        public long UserId { get; set; }
        public UserDto User { get; set; }
        public string MerchantUrl { get; set; }
        public int m_shop { get; set; }
        public int m_orderid { get; set; }
        public double m_amount { get; set; }
        public string m_curr { get; set; }
        public string? m_desc { get; set; }
        public string m_key { get; set; }
        public string sign { get; set; }
        public bool isCompleted { get; set; }
    }
}
