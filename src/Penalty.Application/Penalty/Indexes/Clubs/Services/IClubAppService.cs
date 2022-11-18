using Abp.Application.Services;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Indexes.Clubs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Clubs.Services
{
    public interface IClubAppService : IApplicationService
    {
        IList<ClubDto> GetAll();
        Task<IList<ClubDto>> GetAllClubsAsync();
        Task<ClubDto> GetbyId(Guid id);
        Task<CreateClubDto> Insert(CreateClubDto clubDto);
        Task<UpdateClubDto> Update(UpdateClubDto clubDto);
        void Delete(ClubDto clubDto);
    }
}
