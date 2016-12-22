using DapperExtensions.Mapper;

namespace ProductAPI.Mappers
{
    public class ProductMapper : ClassMapper<Product>
    {
        public ProductMapper()
        {
            base.Schema("dbo");
            base.Table("Products");
            Map(x => x.ProductID).Key(KeyType.Identity);
            AutoMap();
        }
    }
}
