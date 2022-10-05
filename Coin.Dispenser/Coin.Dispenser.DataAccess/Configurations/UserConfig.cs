using Coin.Dispenser.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin.Dispenser.DataAccess.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        internal const int UserId = 1;
        private const string DefaultUser = "FNB";
        private const string DefaultPassword = "123";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = UserId,
                    UserName = DefaultUser,
                    Password = hasher.HashPassword(null, DefaultPassword)
                }
            );
        }
    }
}