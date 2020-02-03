using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevoltTest.Data.ModelConfigurations
{
    public class UserActivityConfig : IEntityTypeConfiguration<UserActivity>
    {
        public void Configure(EntityTypeBuilder<UserActivity> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.DateOfExecution).IsRequired();
            builder.Property(t => t.UserID).IsRequired();
        }
    }
}
