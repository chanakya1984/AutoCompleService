namespace AutoComplete.Repository.Configuration;

using Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal class CarManufactureConfiguration : IEntityTypeConfiguration<CarManufacturer>
{
    public void Configure( EntityTypeBuilder<CarManufacturer> builder )
    {
        builder.ToTable( "CarManufactures" );
        builder.HasKey( nameof(CarManufacturer.Id) );
        builder.Property( x => x.Name ).HasMaxLength( 150 ).IsRequired();
    }
}
