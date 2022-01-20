

using AutoMapper;
using GringottsBank.Infrastructure.MappingProfile;

namespace GringottsBank.DependencyRegistrar
{
    public static class AutoMapperConf
    {
        public static IMapper GetAutoMapperConfiguration()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapping()); });
            return mappingConfig.CreateMapper();
        }
    }
}
