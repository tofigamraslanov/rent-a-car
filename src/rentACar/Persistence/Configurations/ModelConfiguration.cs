using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(k => k.Id);

        builder.Property(p => p.Id).HasColumnName("Id");
        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
        builder.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

        builder.HasOne(m => m.Brand);
    }
}