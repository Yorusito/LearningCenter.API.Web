using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LearningCenter.API.Learning.Domain.Models.ValueObjects;

namespace LearningCenter.API.Learning.Resources;

public class SaveTutorialResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    [Range(1, 3)]
    public ETutorialStatus Status { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}