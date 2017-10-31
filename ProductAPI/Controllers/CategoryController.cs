using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductAPI
{
    public class CategoryController : ApiController
    {
        [HttpGet()]
        public async Task<IEnumerable<Category>> Get(int id)
        {
            IEnumerable<Category> categories= new List<Category>();
            return await CategoryRepository.Get(id);

        }
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            IEnumerable<Category> categories = new List<Category>();
            return await CategoryRepository.Get(null);
        }
    }
}
