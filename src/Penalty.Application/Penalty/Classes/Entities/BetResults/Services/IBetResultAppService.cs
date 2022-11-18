using Abp.Application.Services;
using Penalty.Penalty.Classes.Entities.BetResult.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.BetResults.Services
{
    public interface IBetResultAppService : IApplicationService
    {
        IList<BetResultDto> GetAll();
        IList<BetResultDto> GetAllUserBets();
        Task<IList<BetResultDto>> GetAllBetResultsAsync();
        Task<BetResultDto> GetbyId(Guid id);
        Task<CreateBetResultDto> Insert(CreateBetResultDto betResultDto);
        Task<UpdateBetResultDto> Update(UpdateBetResultDto betResultDto);
        void Delete(BetResultDto betResultDto);
        Task<BetResultDto> GetBetResultbyBetId(Guid id);
    }
}
