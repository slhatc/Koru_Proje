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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.AddressName).HasMaxLength(100);
            builder.Property(I => I.County).HasMaxLength(100).IsRequired();
            builder.Property(I => I.City).HasMaxLength(100).IsRequired();
            builder.Property(I => I.ZipCode).HasMaxLength(100).IsRequired();
        }
    }
}
