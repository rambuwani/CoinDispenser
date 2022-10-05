using Coin.Dispenser.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Dispenser.DataAccess.Constants
{
    public static class CoinCheckBoxList
    {

        public static IEnumerable<CoinCheckBox> List { get; }
            = new List<CoinCheckBox>()
            {
                new CoinCheckBox
                {
                    Id = 1,
                    Text= 1,
                    Value =1
                },
                new CoinCheckBox
                {
                    Id = 2,
                    Text= 2,
                    Value =2
                },
                new CoinCheckBox
                {
                    Id = 3,
                    Text= 5,
                    Value =5
                },
                 new CoinCheckBox
                {
                    Id = 4,
                    Text= 10,
                    Value =10
                },
                new CoinCheckBox
                {
                    Id = 5,
                    Text= 20,
                    Value =20
                },
                 new CoinCheckBox
                {
                     Id = 6,
                    Text= 50,
                    Value =50
                },
                new CoinCheckBox
                {
                    Id = 7,
                    Text= 100,
                    Value =100
                },
                  new CoinCheckBox
                {
                    Id = 8,
                    Text= 200,
                    Value =200
                },
            };
    }
}