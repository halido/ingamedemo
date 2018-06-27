using System.Collections.Generic;
using InGame.BestPractice.Store.Dto;

namespace InGame.BestPractice.Web.Models.Store
{
    public class ProductListViewModel
    {
        public IReadOnlyList<ProductDto> Products { get; set; }
        public IReadOnlyList<CategoryDto> Categories { get; set; }
    }
    public class CategoryListViewModel
    {
        public IReadOnlyList<CategoryDto> Categories { get; set; }
        public IReadOnlyList<CategoryDto> CategoriesHierarchical { get; set; }
    }
}