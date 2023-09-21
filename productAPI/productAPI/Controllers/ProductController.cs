using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using static productAPI.DTO;

namespace productAPI.Controllers
{
    [Route("product")]
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
        public ActionResult<productDTO2> GetById(Guid ID)
        {
            var product = products.Where(x => x.ID == ID).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<productDTO2> PostProduct(CreateProductDTO createProduct)
        {
            var product = new productDTO2(Guid.NewGuid(), createProduct.productName, createProduct.productPrice, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow);
            products.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.ID}, product);
        }

        [HttpPut]
        public productDTO2 PullProduct(Guid ID, UpdateProductDTO updateProduct)
        {
            var existingItem = products.Where(x => x.ID == ID).FirstOrDefault();
            var product = existingItem with
            {
                productName = updateProduct.productName,
                productPrice = updateProduct.productPrice,
                ModifiedTime = DateTimeOffset.UtcNow
            };
            var index = products.FindIndex(x => x.ID == ID);
            products[index] = product;

            return products[index];
        }

        [HttpDelete("{ID}")]

        public ActionResult<string> DeleteProduct(Guid id)
        {
            var index = products.FindIndex(x => x.ID == id);
            products.RemoveAt(index);

            if (index == 0)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
