using Abp.Application.Services.Dto;
using Penalty.Penalty.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSetting.Dto
{
    public class CreateGeneralSettingDto : EntityDto<Guid>
    {
        public string MainAccount { get; set; }
        public string ApiKey { get; set; }
        public string ApiPass { get; set; }
        public string MerchantId { get; set; }
        public double DefaultODD { get; set; }
        public string MerchantUrl { get; set; }
        public int MerchantShop { get; set; }
        public string MerchantSecretKey { get; set; }
        public string WebsiteDeafultLink { get; set; }
    }
}
