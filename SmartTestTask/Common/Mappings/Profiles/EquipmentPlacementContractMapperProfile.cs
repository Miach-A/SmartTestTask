using AutoMapper;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Commands.Create;
using SmartTestTask.CQRS.EquipmentPlacementContracts.Queries.GetEquipmentPlacementContract;
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

            CreateMap<EquipmentPlacementContract, EquipmentPlacementContractDto>()
                .ForMember(x => x.ProductionPremises, y => y.MapFrom(x => x.ProductionPremises.Name))
                .ForMember(x => x.TypeOfEquipment, y => y.MapFrom(x => x.TypeOfEquipment.Name));


        }
    }
}
