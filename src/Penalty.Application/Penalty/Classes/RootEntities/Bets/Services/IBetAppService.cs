using Abp.Application.Services;
using Penalty.Penalty.Classes.RootEntities.Bets.Dto;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Bets.Services
{
    public interface IBetAppService : IApplicationService
    {
        IList<BetDto> GetAll();
        IList<BetDto> GetUserBets();
        Task<IList<BetDto>> GetAllBetsAsync();
        Task<BetDto> GetbyId(Guid id);
        Task<CreateBetDto> Insert(CreateBetDto betDto);
        Task<UpdateBetDto> Update(UpdateBetDto betDto);
        void Delete(BetDto betDto);
    }
}
