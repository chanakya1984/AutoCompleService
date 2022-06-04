namespace AutoComplete.Repository.Configuration;

using Entities;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public class CarModelConfigurations : IEntityTypeConfiguration<CarModel>
{
    public void Configure( EntityTypeBuilder<CarModel> builder )
    {
        builder.ToTable( "CarModels" );
        builder.HasKey( nameof(CarModel.Id) );
        builder.Property( x => x.EngineCapacity ).HasMaxLength( 10 ).IsRequired();
        builder.Property( x => x.FuelType ).IsRequired();
        builder.Property( x => x.Name ).HasMaxLength( 100 ).IsRequired();
    }
}
