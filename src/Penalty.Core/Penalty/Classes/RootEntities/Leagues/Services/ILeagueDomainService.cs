using Abp.Domain.Services;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Services
{
    public interface ILeagueDomainService : IDomainService
    {
        IList<League> GetAll();
        Task<IList<League>> GetAllLeaguesAsync();
        Task<League> GetbyId(Guid id);
        Task<League> Insert(League league);
        Task<League> Update(League league);
        void Delete(Guid id);
    }
}
