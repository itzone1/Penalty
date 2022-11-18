using Abp.Application.Services;
using Penalty.Penalty.Indexes.Countries.Dto;
using Penalty.Penalty.Indexes.LeagueTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.LeagueTypes.Services
{
    public interface ILeagueTypeAppService : IApplicationService
    {
        IList<LeagueTypeDto> GetAll();
        Task<IList<LeagueTypeDto>> GetAllLeagueTypesAsync();
        Task<LeagueTypeDto> GetbyId(Guid id);
        Task<CreateLeagueTypeDto> Insert(CreateLeagueTypeDto leagueTypeDto);
        Task<UpdateLeagueTypeDto> Update(UpdateLeagueTypeDto leagueTypeDto);
        void Delete(LeagueTypeDto leagueTypeDto);
    }
}
