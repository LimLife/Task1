using Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(primaryKey => primaryKey.Id);

            builder.Property(name => name.CompanyName);
            builder.Property(city => city.City);
            builder.Property(state => state.State);
            builder.Property(phone => phone.Phone);
            builder.HasMany(store => store.Stores).WithOne(comany => comany.Company).HasForeignKey(foreignKey => foreignKey.CompanyID);
        }
    }
}
