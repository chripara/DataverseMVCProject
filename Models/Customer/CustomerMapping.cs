using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataverseMVCProject.Models.Customer
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.ContactPhone).HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(30);
            builder.Property(p => p.Firstname).HasMaxLength(50);
            builder.Property(p => p.Surname).HasMaxLength(50);
            builder.Property(p => p.Address).HasMaxLength(50);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            //Seed Db
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    ContactPhone = "+306948521396",
                    Email = "HamedJeihlan@gmail.com",
                    Firstname = "Hamed",
                    Surname = "Jeihlan",
                    Address = "4083 Bluff Street"
                },
                new Customer
                {
                    Id = 2,
                    ContactPhone = "+306948521391",
                    Email = "LongLien@gmail.com",
                    Firstname = "Long",
                    Surname = "Lien",
                    Address = "1079 West Street"
                },
                new Customer
                {
                    Id = 3,
                    ContactPhone = "+306948321396",
                    Email = "HamedJeihlan@gmail.com",
                    Firstname = "Hamed",
                    Surname = "Jeihlan",
                    Address = "1180 West Fork Drive"
                },
                new Customer
                {
                    Id = 4,
                    ContactPhone = "+306948621396",
                    Email = "AdrinDatsk@gmail.com",
                    Firstname = "Adrin",
                    Surname = "Datsk",
                    Address = "3841 Agriculture Lane"
                },
                new Customer
                {
                    Id = 5,
                    ContactPhone = "+306948521296",
                    Email = "DostilOnzurnes@gmail.com",
                    Firstname = "Dostil",
                    Surname = "Onzurnes",
                    Address = "288 Ridenour Street"
                });
        }
    }
}