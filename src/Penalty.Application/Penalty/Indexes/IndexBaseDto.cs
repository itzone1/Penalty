using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes
{
    public class IndexBaseDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
