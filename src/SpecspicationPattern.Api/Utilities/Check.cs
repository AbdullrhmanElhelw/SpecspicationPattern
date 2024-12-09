namespace SpecspicationPattern.Api.Utilities;

public static class Check
{
    public static void NotNull<T>(T value, string name)
    {
        if (value == null)
        {
            throw new ArgumentNullException(name);
        }
    }

    public static void NotEmpty(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(name);
        }
    }
}