using System.Globalization;

namespace productAPI
{
    public class DTO
    {
        public record productDTO2(Guid ID, string productName, int productPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);
        public record CreateProductDTO(string productName, int productPrice);
        public record UpdateProductDTO(string productName, int productPrice);
    }
}
