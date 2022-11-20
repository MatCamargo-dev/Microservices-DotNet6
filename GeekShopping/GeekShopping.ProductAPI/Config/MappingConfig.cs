using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVo, ProductVo>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
