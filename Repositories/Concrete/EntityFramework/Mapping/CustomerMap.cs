using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EntityFramework.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Email).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Phone).HasMaxLength(100).IsRequired();
            builder.HasOne<Address>(c => c.Address).WithOne().HasForeignKey<Customer>(c => c.AddressId);

            //builder.HasIndex(I => new { I.AddressId, I.Id }).IsUnique();
            //builder.HasOne<Address>(s => s.Address)
            //.WithOne(ad => ad.Customer)
            //.HasForeignKey<Address>(ad => ad.Id);
        }
    }
}
