using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.BetResult.Dto
{
    public class UpdateBetResultDto : EntityDto<Guid>
    {
        public Guid BetId { get; set; }
        public int Result { get; set; }
        public Guid MatchResultId { get; set; }
        public bool isPaid { get; set; }
        public string? Description { get; set; }
    }
}
