using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Penalty.Authorization.Roles;
using Penalty.Authorization.Users;
using Penalty.MultiTenancy;
using Penalty.Penalty.Classes.Entities.BetResults;
using Penalty.Penalty.Classes.Entities.Matches;
using Penalty.Penalty.Classes.Entities.MatchResults;
using Penalty.Penalty.Classes.RootEntities.Bets;
using Penalty.Penalty.Classes.RootEntities.Leagues;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Indexes.Clubs;
using Penalty.Penalty.Indexes.Countries;
using Penalty.Penalty.Indexes.LeagueTypes;
using Penalty.Penalty.Classes.RootEntities;

namespace Penalty.EntityFrameworkCore
{
    public class PenaltyDbContext : AbpZeroDbContext<Tenant, Role, User, PenaltyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public PenaltyDbContext(DbContextOptions<PenaltyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<LeagueType> LeagueTypes { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<GeneralSettings> GeneralSettings { get; set; }
        public DbSet<League> League { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<BetResult> BetResults { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchResult> MatchResults { get; set; }
    }
}
