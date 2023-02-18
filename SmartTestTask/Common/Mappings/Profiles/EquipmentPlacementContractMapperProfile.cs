using AutoMapper;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Commands.Create;
using SmartTestTaskModel;

namespace SmartTestTask.Common.Mappings.Profiles
{
    public class EquipmentPlacementContractMapperProfile : Profile
    {
        public EquipmentPlacementContractMapperProfile()
        {
            CreateMap<CreateEquipmentPlacementContractCommand, EquipmentPlacementContract>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.ProductionPremises, y => y.Ignore())
                .ForMember(x => x.TypeOfEquipment, y => y.Ignore());
        }
    }
}
