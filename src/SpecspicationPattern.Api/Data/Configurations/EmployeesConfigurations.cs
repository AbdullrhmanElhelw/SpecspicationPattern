using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecspicationPattern.Api.Models.Employees;

namespace SpecspicationPattern.Api.Data.Configurations;

internal sealed class EmployeesConfigurations : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.OwnsOne(e => e.FirstName, fn =>
        {
            fn.Property(fn => fn.Value)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.OwnsOne(e => e.LastName, ln =>
        {
            ln.Property(ln => ln.Value)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.HasMany(e => e.EmployeeProjects)
            .WithOne(ep => ep.Employee)
            .HasForeignKey(ep => ep.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}