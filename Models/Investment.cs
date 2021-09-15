
namespace CryppitBackend.Models
{
    public class Investment
    {
        public CryptoDetail Crypto { get; set; }
        public double PriceBought { get; set; }

        public double Amount { get; set; }

        public CryptoGraph Graph { get; set; }
    }
}
