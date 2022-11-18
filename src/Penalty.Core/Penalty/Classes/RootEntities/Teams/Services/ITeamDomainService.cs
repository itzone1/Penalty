using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Services
{
    public interface ITeamDomainService : IDomainService
    {
        IList<Team> GetAll();
        Task<IList<Team>> GetAllTeamsAsync();
        Task<Team> GetbyId(Guid id);
        Task<Team> Insert(Team team);
        Task<Team> Update(Team team);
        void Delete(Team team);
    }
}
