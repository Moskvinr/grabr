using System;
using System.Collections.Generic;
using System.Text;
using GrabrReplica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrabrReplica.Persistance.Configurations
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(300);
            builder.Property(p => p.Count).IsRequired();

            builder.HasOne(p => p.OrderBy)
                .WithMany(p => p.UserOrders)
                .HasForeignKey(p => p.OrderByUserId);
            builder.HasOne(p => p.DeliveryMan)
                .WithMany(p => p.OrdersDelivered)
                .HasForeignKey(p => p.DeliveryManUserId);
        }
    }
}