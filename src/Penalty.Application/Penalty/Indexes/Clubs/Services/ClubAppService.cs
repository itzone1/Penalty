using Abp.Authorization;
using Penalty.Authorization;
using Penalty.Penalty.Classes.RootEntities.Teams;
using Penalty.Penalty.Classes.RootEntities.Teams.Dto;
using Penalty.Penalty.Classes.RootEntities.Teams.Services;
using Penalty.Penalty.Indexes.Clubs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Indexes.Clubs.Services
{
    public class ClubAppService : PenaltyAppServiceBase, IClubAppService
    {
        private readonly IClubDomainService _clubDomainService;

        public ClubAppService(IClubDomainService clubDomainService)
        {
            _clubDomainService = clubDomainService;
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public void Delete(ClubDto clubDto)
        {
            var club = ObjectMapper.Map<Club>(clubDto);
            _clubDomainService.Delete(club);
        }

        public IList<ClubDto> GetAll()
        {
            var clubs = _clubDomainService.GetAll();
            return ObjectMapper.Map<List<ClubDto>>(clubs);
        }

        public async Task<IList<ClubDto>> GetAllClubsAsync()
        {
            var clubs = _clubDomainService.GetAllClubsAsync();
            return ObjectMapper.Map<List<ClubDto>>(clubs);
        }

        public async Task<ClubDto> GetbyId(Guid id)
        {
            var club = await _clubDomainService.GetbyId(id);
            return ObjectMapper.Map<ClubDto>(club);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<CreateClubDto> Insert(CreateClubDto clubDto)
        {
            var club = ObjectMapper.Map<Club>(clubDto);
            var createdClub = await _clubDomainService.Insert(club);
            return ObjectMapper.Map<CreateClubDto>(createdClub);
        }
        [AbpAuthorize(PermissionNames.Pages_Users_Activation)]
        public async Task<UpdateClubDto> Update(UpdateClubDto clubDto)
        {
            var club = await _clubDomainService.GetbyId(clubDto.Id);
            ObjectMapper.Map<UpdateClubDto, Club>(clubDto, club);
            var updatedClub = await _clubDomainService.Update(club);
            return ObjectMapper.Map<UpdateClubDto>(updatedClub);
        }
    }
}
