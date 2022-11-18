using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Services
{
    public interface IMatchResultDomainService : IDomainService
    {
        IList<MatchResult> GetAll();
        Task<IList<MatchResult>> GetAllMatchResultsAsync();
        Task<MatchResult> GetbyId(Guid id);
        Task<MatchResult> Insert(MatchResult matchResult);
        Task<MatchResult> Update(MatchResult matchResult);
        void Delete(MatchResult matchResult);
    }
}
