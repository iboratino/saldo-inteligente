using AutoMapper;

namespace SaldoInteligente.Services.AutoMapper
{
    public class AutoMapperConfig
    {
        private readonly IMapper mapper;

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(c =>
            {
                c.AddProfile(new DTOToEntityMappingProfile());
                c.AddProfile(new EntityToResponseProfile());
            });
        }
    }
}
