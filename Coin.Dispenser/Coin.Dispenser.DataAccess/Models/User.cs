using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Dispenser.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
