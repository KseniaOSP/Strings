using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Training

{
    interface IPriceChange
    {
        void PriceChange(int a);
  
    }
    public class StockExchangeMonitor: IPriceChange
    {

        public void PriceChange(int price)
        {
            Console.WriteLine($"New Price is: {price}");
            
        }

        public void Start()
        {
            while (true) 
            {
                int bankOfAmericaPrice = (new Random()).Next(100);
                PriceChange(bankOfAmericaPrice);
                Thread.Sleep(2000);
            }
        }


    }
}
