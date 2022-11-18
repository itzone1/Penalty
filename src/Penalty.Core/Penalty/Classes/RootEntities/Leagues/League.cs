using Abp.Domain.Entities.Auditing;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Indexes.LeagueTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues
{
    public class League : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

       // [ForeignKey("LeagueType")]
        public string LeagueApiKey { get; set; }
        public Guid LeagueTypeId { get; set; }
        public LeagueType LeagueType { get; set; }
        public string? Description { get; set; }
    }
}
