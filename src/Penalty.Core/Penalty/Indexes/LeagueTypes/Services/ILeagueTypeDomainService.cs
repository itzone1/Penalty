using Abp.Domain.Services;
using Penalty.Penalty.Indexes.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.LeagueTypes.Services
{
    public interface ILeagueTypeDomainService : IDomainService
    {
        IList<LeagueType> GetAll();
        Task<IList<LeagueType>> GetAllLeaguesAsync();
        Task<LeagueType> GetbyId(Guid id);
        Task<LeagueType> Insert(LeagueType leagueType);
        Task<LeagueType> Update(LeagueType leagueType);
        void Delete(LeagueType leagueType);
    }
}
