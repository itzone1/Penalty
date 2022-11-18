using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.Teams.Services
{
    public interface ITeamAppService : IApplicationService
    {
        IList<TeamDto> GetAll();
        Task<IList<TeamDto>> GetAllTeamsAsync();
        Task<TeamDto> GetbyId(Guid id);
        Task<CreateTeamDto> Insert(CreateTeamDto teamdto);
        Task<UpdateTeamDto> Update(UpdateTeamDto teamdto);
        void Delete(TeamDto teamdto);
        [HttpGet]
        Task BackGroundWorker();
    }
}
