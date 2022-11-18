using Abp.Application.Services;
using Penalty.Penalty.Classes.Entities.Matches.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.Entities.Matches.Services
{
    public interface IMatchAppService : IApplicationService
    {
        IList<MatchDto> GetAll();
        IList<MatchDto> GetAllNotStartedMatches();
        IList<MatchDto> GetAllPendingMatches();
        IList<MatchDto> GetAllFinishedMatches();
        Task<IList<MatchDto>> GetAllMatchesAsync();
        Task<MatchDto> GetbyId(Guid id);
        Task<CreateMatchDto> Insert(CreateMatchDto matchdto);
        Task<UpdateMatchDto> Update(UpdateMatchDto matchdto);
        void Delete(MatchDto matchdto);
    }
}
