using Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(primaryKey => primaryKey.Id);
            builder.Property(orderdate => orderdate.OrderDate);
            builder.Property(invoice => invoice.InvoiceNumber);
        }
    }
}
