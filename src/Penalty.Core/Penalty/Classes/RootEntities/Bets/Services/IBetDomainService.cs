using Abp.Domain.Services;
using Penalty.Penalty.Classes.RootEntities.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Services
{
    public interface IBetDomainService : IDomainService
    {
        IList<Bet> GetAll();
        Task<IList<Bet>> GetUserBets();
        Task<IList<Bet>> GetAllBetsAsync();
        Task<Bet> GetbyId(Guid id);
        Task<Bet> Insert(Bet bet);
        Task<Bet> Update(Bet bet);
        void Delete(Bet bet);
    }
}
