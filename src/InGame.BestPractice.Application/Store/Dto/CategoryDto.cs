using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AutoMapper;

namespace InGame.BestPractice.Store.Dto
{
    [AutoMapFrom(typeof(Category))]
    
    public class CategoryDto : EntityDto<int>
    {
        [Required]
        [StringLength(Category.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(Category.MaxDescriptionLength)]
        public string Description { get; set; }
        public List<CategoryDto> SubCategories { get; set; }
        public int? ParentCategoryId { get; set; }

    }
    [AutoMapTo(typeof(Category))]
    public class CreateCategoryDto 
    {
        [Required]
        [StringLength(Category.MaxNameLength)]
        public string Name { get; set; }
        [StringLength(Category.MaxDescriptionLength)]
        public string Description { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}