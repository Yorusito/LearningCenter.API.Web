using LearningCenter.API.Learning.Domain.Models.Aggregates;

namespace LearningCenter.API.Learning.Domain.Models.Entities;

public partial class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Relationships
    
    public IList<Tutorial> Tutorials { get; set; } = new List<Tutorial>();
    
}
