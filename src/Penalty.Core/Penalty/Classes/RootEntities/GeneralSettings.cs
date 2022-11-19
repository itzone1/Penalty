using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities
{
    public class GeneralSettings : FullAuditedAggregateRoot<Guid>
    {
        public string ApiKey { get; set; }
        public double DefaultODD { get; set; }
        public string MerchantUrl { get; set; }
        public int MerchantShop { get; set; }
        public string MerchantSecretKey { get; set; }
    }
}
