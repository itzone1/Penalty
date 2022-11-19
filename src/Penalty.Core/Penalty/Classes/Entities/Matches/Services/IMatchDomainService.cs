using Abp.Domain.Services;
using Penalty.Penalty.Classes.RootEntities.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.Matches.Services
{
    public interface IMatchDomainService : IDomainService
    {
        IList<Match> GetAll();
        IList<Match> GetAllNotStartedMatches();
        IList<Match> GetAllPendingMatches();
        IList<Match> GetAllFinishedMatches();
        Task<IList<Match>> GetAllMatchesAsync();
        Task<Match> GetbyId(Guid id);
        Task<Match> Insert(Match match);
        Task<Match> Update(Match match);
        void Delete(Guid id);
    }
}
