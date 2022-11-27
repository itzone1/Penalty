using Abp.Domain.Entities.Auditing;
using Penalty.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.InvitedUsers
{
    public class InvitedUser : FullAuditedAggregateRoot<Guid>
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("InvitedByUser")]
        public long InvitedByUserId { get; set; }
        public User InvitedByUser { get; set; }
<<<<<<< Updated upstream
        public bool IsActivated { get; set; }
        public bool IsPaid { get; set; }
=======
        public bool isActivated { get; set; }
        public bool PaidForUser { get; set; }
>>>>>>> Stashed changes
    }
}
