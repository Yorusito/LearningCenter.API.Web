

using LearningCenter.API.Learning.Domain.Models.ValueObjects;

namespace LearningCenter.API.Learning.Resources;

public class TutorialResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ETutorialStatus Status { get; set; }
    public string SerialNumber { get; set; }
    public CategoryResource Category { get; set; }

    // Nueva propiedad para la representación de cadena del estado
    public string StatusString
    {
        get { return GetStatusString(Status); }
    }

    // Método para convertir el valor del enumerado a su representación de cadena
    private static string GetStatusString(ETutorialStatus status)
    {
        switch (status)
        {
            case ETutorialStatus.NotStarted:
                return "NotStarted";
            case ETutorialStatus.InProgress:
                return "InProgress";
            case ETutorialStatus.Finished:
                return "Finished";
            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }
    }
}