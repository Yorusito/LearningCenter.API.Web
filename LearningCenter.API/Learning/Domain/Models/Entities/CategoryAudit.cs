using System.ComponentModel.DataAnnotations.Schema;

namespace LearningCenter.API.Learning.Domain.Models.Entities;

public partial class Category
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }

    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}