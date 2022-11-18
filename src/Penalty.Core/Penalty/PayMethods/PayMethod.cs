using Abp.Domain.Entities.Auditing;
using Penalty.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.PayMethods
{
    public class PayMethod : FullAuditedAggregateRoot<Guid>
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        public bool isActive { get; set; }
        public string AccountNumber { get; set; }
        public string SecretKey { get; set; }
    }
}
