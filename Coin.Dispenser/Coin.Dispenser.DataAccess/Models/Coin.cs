using System;
using System.ComponentModel.DataAnnotations;

namespace Coin.Dispenser.DataAccess.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int Text { get; set; }
        public bool IsChecked { get; set; }

    }
}
