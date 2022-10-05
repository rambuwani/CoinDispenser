using System.Linq;

namespace Coin.Dispenser.Configurations
{
    public class CorsOptions
    {
        public string AllowedOrigins { get; set; }

        public string[] GetAllowedOriginsAsArray()
        {
            return AllowedOrigins
                .Split(',')
                .Select(o => o.Trim())
                .ToArray();
        }
    }
}
