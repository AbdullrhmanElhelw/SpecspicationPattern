namespace SpecspicationPattern.Api.Controllers.Infrastructure;

public static class ApiRoutes
{
    private const string ApiBase = "api/v1";

    public static class Departments
    {
        public const string Base = ApiBase + "/departments";

        public const string GetById = "{id}";

        public const string GetAll = "";
    }
}