using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Newtonsoft.Json;

namespace InGame.BestPractice.Store.Dto
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto
    {
        [StringLength(Product.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        [StringLength(Product.MaxImageLength)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        [StringLength(Product.MaxDescriptionLength)]
        public string Description { get; set; }

        public string CategoryName { get; set; }
        public string Slug { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
    [AutoMapTo(typeof(Product))]
    public class CreateProductDto
    {
        [StringLength(Product.MaxNameLength)]
        [Required]
        public string Name { get; set; }
        [StringLength(Product.MaxImageLength)]
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        [StringLength(Product.MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

    }
}
