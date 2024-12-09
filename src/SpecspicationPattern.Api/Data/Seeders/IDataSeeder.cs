namespace SpecspicationPattern.Api.Data.Seeders;

public interface IDataSeeder
{
    Task SeedAsync(ApplicationDbContext context);
}