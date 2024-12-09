using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecspicationPattern.Api.Models.Departments;

namespace SpecspicationPattern.Api.Data.Configurations;

internal sealed class DepartmentsConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.OwnsOne(d => d.Name, n =>
        {
            n.Property(name => name.Value)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.OwnsOne(d => d.Code, c =>
        {
            c.Property(code => code.Value)
                .HasColumnName("Code")
                .HasMaxLength(10)
                .IsRequired();
        });

        builder.OwnsOne(d => d.Description, d =>
        {
            d.Property(description => description.Value)
                .HasColumnName("Description")
                .HasMaxLength(500)
                .IsRequired();
        });

        builder.HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.Projects)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}