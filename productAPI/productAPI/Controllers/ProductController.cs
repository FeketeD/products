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
    }
}
