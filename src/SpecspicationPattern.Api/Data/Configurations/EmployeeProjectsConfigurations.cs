using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecspicationPattern.Api.Models.EmployeeProjects;

namespace SpecspicationPattern.Api.Data.Configurations;

internal sealed class EmployeeProjectsConfigurations : IEntityTypeConfiguration<EmployeeProject>
{
    public void Configure(EntityTypeBuilder<EmployeeProject> builder)
    {
        builder.ToTable("EmployeeProjects");

        builder.HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
    }
}