using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Models.Aggregates;
using LearningCenter.API.Learning.Domain.Models.Entities;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Domain.Services;

public interface ICategoryService
{
    Task<Category> GetByIdAsync(int id);
    Task<IEnumerable<Category>> ListAsync();

    
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int id, Category category);
    Task<CategoryResponse> DeleteAsync(int id);
}