using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static productAPI.DTO;

namespace productAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<productDTO2> products = new()
        {
            new productDTO2(Guid.NewGuid(), "termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new productDTO2(Guid.NewGuid(), "termék2", 3500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new productDTO2(Guid.NewGuid(), "termék3", 4500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow)
        };
        [HttpGet]
        public IEnumerable<productDTO2> GetAll()
        {
            return products;
        }

        [HttpGet("{ID}")]
        public productDTO2 GetById(Guid ID)
        {
            var product = products.Where(x => x.ID == ID).FirstOrDefault();
            return product;
        }

        [HttpPost]
        public productDTO2 PostProduct(CreateProductDTO createProduct)
        {
            var product = new productDTO2(Guid.NewGuid(), createProduct.productName, createProduct.productPrice, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            products.Add(product);
            return product;
        }
    }
}
