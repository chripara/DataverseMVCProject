using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataverseMVCProject.Models.Customer
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.ContactPhone).HasMaxLength(20);
            builder.Property(p => p.Firstname).HasMaxLength(50);
            builder.Property(p => p.Surname).HasMaxLength(50);
            builder.Property(p => p.Address).HasMaxLength(50);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
