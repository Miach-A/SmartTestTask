using AutoMapper;
using SmartTestTask.Common.Models;
using SmartTestTaskModel;

namespace SmartTestTask.Common.Mappings.Profiles
{
    public class EquipmentPlacementContractMapperProfile : Profile
    {
        public EquipmentPlacementContractMapperProfile()
        {
            CreateMap<EquipmentPlacementContract, EquipmentPlacementContractDTO>();
        }
    }
}
