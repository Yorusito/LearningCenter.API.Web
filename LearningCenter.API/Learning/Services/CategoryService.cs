using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Learning.Domain.Models.Aggregates;
using LearningCenter.API.Learning.Domain.Models.Entities;
using LearningCenter.API.Learning.Domain.Repositories;
using LearningCenter.API.Learning.Domain.Services;
using LearningCenter.API.Learning.Domain.Services.Communication;

namespace LearningCenter.API.Learning.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Category> GetByIdAsync(int id)
    {
        var category = await _categoryRepository.FindByIdAsync(id);
        if (category == null) throw new KeyNotFoundException("Category not found");
        return category;
    }
    
    
    

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }

    public async Task<CategoryResponse> SaveAsync(Category category)
    {
        try
        {
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(category);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> UpdateAsync(int id, Category category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        existingCategory.Name = category.Name;

        try
        {
            _categoryRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(int id)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);

        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        try
        {
            _categoryRepository.Remove(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new CategoryResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}