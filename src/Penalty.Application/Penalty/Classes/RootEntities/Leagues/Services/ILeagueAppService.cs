using Abp.Application.Services;
using Penalty.Penalty.Classes.RootEntities.Leagues.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Indexes.LeagueTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Leagues.Services
{
    public interface ILeagueAppService : IApplicationService
    {
        IList<LeagueDto> GetAll();
        Task<IList<LeagueDto>> GetAllLeaguesAsync();
        Task<LeagueDto> GetbyId(Guid id);
        Task<CreateLeagueDto> Insert(CreateLeagueDto leagueDto);
        Task<UpdateLeagueDto> Update(UpdateLeagueDto leagueDto);
        void Delete(Guid id);
        IList<LeagueTypeDto> GetLeagueTypeLookup();
    }
}
