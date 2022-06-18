using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Id).ValueGeneratedOnAdd();
            builder.Property(order => order.OrderDate).IsRequired();           
            builder.Property(order => order.CreateBy).IsRequired();

            builder.Property(order => order.OderNo).HasMaxLength(100);           
            builder.HasIndex(x => x.OderNo).IsUnique();
        }
    }
}
