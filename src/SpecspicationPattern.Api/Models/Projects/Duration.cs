namespace SpecspicationPattern.Api.Models.Projects;

public record Duration(DateTime StartDate, DateTime EndDate)
{
    public bool IsWithin(DateTime date)
    {
        return date >= StartDate && date <= EndDate;
    }

    public bool IsOverlapping(Duration duration)
    {
        return IsWithin(duration.StartDate) || IsWithin(duration.EndDate);
    }
}