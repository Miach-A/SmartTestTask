using AutoMapper;
using SmartTestTask.Common.Mappings.Profiles;

namespace SmartTestTaskTests
{
    public static class AutoMaperHelper
    {
        private static IMapper _mapper;
        static AutoMaperHelper()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EquipmentPlacementContractMapperProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        public static IMapper Mapper => _mapper;
    }
}
