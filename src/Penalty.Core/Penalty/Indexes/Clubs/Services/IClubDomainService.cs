using Abp.Domain.Services;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Clubs.Services
{
    public interface IClubDomainService : IDomainService
    {
        IList<Club> GetAll();
        Task<IList<Club>> GetAllClubsAsync();
        Task<Club> GetbyId(Guid id);
        Task<Club> Insert(Club club);
        Task<Club> Update(Club club);
        void Delete(Club club);
    }
}
