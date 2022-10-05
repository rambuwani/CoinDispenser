using Coin.Dispenser.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Dispenser.DataAccess.Configurations
{
        public class CoinCheckBoxConfig : IEntityTypeConfiguration<CoinCheckBox>
        {
            public void Configure(EntityTypeBuilder<CoinCheckBox> builder)
            {
                builder.HasData(Constants.CoinCheckBoxList.List);
            }
        }
    }
