using Entity.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(primaryKey => primaryKey.Id);

            builder.Property(firstName => firstName.FirstName);
            builder.Property(lastName => lastName.LastName);
            builder.Property(title => title.Title);
            builder.Property(postion => postion.Position);
            builder.Property(birthdate => birthdate.BirthDate);
            builder.HasOne(store => store.Store).WithMany(employee => employee.Employees).HasForeignKey(foreignKey => foreignKey.StoreId);
        }
    }
}
