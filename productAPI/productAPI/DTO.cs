using System.Globalization;

namespace productAPI
{
    public class DTO
    {
        public record productDTO2(Guid ID, string productNeve, int ProductAr, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);
    }
}
