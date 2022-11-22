using AutoMapper;
using Penalty.Penalty.Classes.RootEntities.GeneralSetting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Penalty.Classes.RootEntities.GeneralSetting.Map
{
    public class GeneralSettingMapProfile : Profile
    {
        public GeneralSettingMapProfile()
        {
            CreateMap<GeneralSettings, GeneralSettingDto>();
            CreateMap<GeneralSettings, CreateGeneralSettingDto>();
            CreateMap<GeneralSettings, UpdateGeneralSettingDto>();
            CreateMap<GeneralSettingDto, GeneralSettings>();
            CreateMap<CreateGeneralSettingDto, GeneralSettings>();
            CreateMap<UpdateGeneralSettingDto, GeneralSettings>();
        }
    }
}
