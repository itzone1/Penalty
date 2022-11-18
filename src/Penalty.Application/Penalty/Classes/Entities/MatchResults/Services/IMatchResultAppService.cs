using Abp.Application.Services;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using Penalty.Penalty.Classes.Entities.MatchResults.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.MatchResults.Services
{
    public interface IMatchResultAppService : IApplicationService
    {
        IList<MatchResultDto> GetAll();
        Task<IList<MatchResultDto>> GetAllMatchResultsAsync();
        Task<MatchResultDto> GetbyId(Guid id);
        Task<CreateMatchResultDto> Insert(CreateMatchResultDto matchresultdto);
        Task<UpdateMatchResultDto> Update(UpdateMatchResultDto matchresultdto);
        void Delete(MatchResultDto matchresultdto);
    }
}
