using Abp.Domain.Entities.Auditing;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using Penalty.Penalty.Indexes.Clubs;
using Penalty.Penalty.Indexes.Countries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams
{
    public class Team : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        #region Country
        public Country? Country { get; set; }
        //[ForeignKey("Country")]
        public Guid? CountryId { get; set; }
        #endregion
        #region Club
        public Club? Club { get; set; }
      //  [ForeignKey("Club")]
        public Guid? ClubId { get; set; }
        #endregion
        //#region League
        //public League? League { get; set; }
        //[ForeignKey("League")]
        //public Guid? LeagueId { get; set; }
        //#endregion
        public bool? isNationalTeam { get; set; }
        public string? Description { get; set; }
    }
}
