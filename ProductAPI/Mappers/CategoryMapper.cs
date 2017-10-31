using DapperExtensions.Mapper;

namespace ProductAPI.Mappers
{
    public class CategoryMapper : ClassMapper<Category>
    {
        public CategoryMapper()
        {
            base.Schema("dbo");
            base.Table("Category");
            Map(x => x.CategoryID).Key(KeyType.Identity);
            AutoMap();
        }
    }
}
