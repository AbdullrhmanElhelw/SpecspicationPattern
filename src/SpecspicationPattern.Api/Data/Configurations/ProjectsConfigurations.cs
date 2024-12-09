using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPattern.Data.Converters;
using SpecspicationPattern.Api.Models.Projects;

internal sealed class ProjectsConfigurations : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.Name, n =>
        {
            n.Property(name => name.Value)
                .HasColumnName("Name")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.OwnsOne(p => p.Duration, d =>
        {
            d.Property(d => d.StartDate)
                .HasColumnName("StartDate")
                .IsRequired();

            d.Property(d => d.EndDate)
                .HasColumnName("EndDate")
                .IsRequired();
        });

        // Configure Money with Currency mapping
        var currencyConverter = new CurrencyValueConverter();

        builder.OwnsOne(p => p.Budget, b =>
        {
            b.Property(b => b.Amount)
                .HasColumnName("Amount")
                .IsRequired();

            b.Property(b => b.Currency)
                .HasColumnName("Currency")
                .HasMaxLength(3)
                .IsRequired()
                .HasConversion(currencyConverter);
        });

        builder.HasMany(p => p.EmployeeProjects)
            .WithOne(ep => ep.Project)
            .HasForeignKey(ep => ep.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}