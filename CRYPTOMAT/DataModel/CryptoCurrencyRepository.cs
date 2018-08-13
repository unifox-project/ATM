using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRYPTOMAT
{
    public class CryptoCurrencyRepository
    {
        private  List<CryptoCurrency> _cryptoCurrencies;
        public CryptoCurrencyRepository()
        {
            _cryptoCurrencies = new List<CryptoCurrency>();
            _cryptoCurrencies.Add(new CryptoCurrency(1, "BTC", "Bitcoin", 7043.4));
            _cryptoCurrencies.Add(new CryptoCurrency(2, "ETH", "Ethereum", 409.11));
            _cryptoCurrencies.Add(new CryptoCurrency(3, "DASH", "DASH", 201.76));
            _cryptoCurrencies.Add(new CryptoCurrency(4, "SC", "SCUDO", 1));
            _cryptoCurrencies.Add(new CryptoCurrency(5, "DBD", "Diamondbond", 10));
            _cryptoCurrencies.Add(new CryptoCurrency(6, "UXC", "UNICASH", 1));
            _cryptoCurrencies.Add(new CryptoCurrency(7, "FOX", "UNIFOX", 10));
            _cryptoCurrencies.Add(new CryptoCurrency(8, "ECA", "Electra", 350));
        }

        public CryptoCurrency GetCryptoCurrencyById(int id)
        {
            return _cryptoCurrencies.Find(t => t.Id == id);
        }

    }




}
