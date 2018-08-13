using System.Globalization;

namespace CRYPTOMAT
{
    public class CryptoCurrency
    {
        public CryptoCurrency()
        {
            
        }

        public CryptoCurrency(int id, string name, string fullName, double exchangeRate)
        {
            Id = id;
            Name = name;
            ExchangeRate = exchangeRate;
            FullName = fullName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public double ExchangeRate { get; set; }


        public override string ToString()
        {
            return string.Format("1 {0} = {1} EUR", Name, ExchangeRate.ToString("F2", CultureInfo.InvariantCulture));
        }

    }
}