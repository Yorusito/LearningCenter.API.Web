using LearningCenter.API.Learning.Domain.Models.Entities;
using LearningCenter.API.Learning.Domain.Models.ValueObjects;

namespace LearningCenter.API.Learning.Domain.Models.Aggregates;

public partial class Tutorial
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ETutorialStatus Status { get; set; }
    
    // Call the GenerateSerialNumber() method to generate a serial number for the tutorial
    public string SerialNumber { get; set; } = GenerateSerialNumber();
    
    // Relationships
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    private static string GenerateSerialNumber()
    {
        return Guid.NewGuid().ToString("N");
    }
}