using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace InGame.BestPractice.Store
{
    public class Product : AuditedEntity,IDeletionAudited
    {
        public const int MaxNameLength = 255;
        public const int MaxDescriptionLength = 255 * 255;
        public const int MaxSlugLength = 255;
        public const int MaxImageLength = 255*255;

        public Category Category { get; set; }
        [MaxLength(MaxNameLength)]
        [Required]
        public string Name { get; set; }
        [MaxLength(MaxImageLength)]
        public string ImageUrl { get; set; }
        [MaxLength(MaxSlugLength)]
        [Required]
        public string Slug { get; set; }
        public decimal Price { get; set; }
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        //Key Property Of Category
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        //Active geçici devre dışı bırakılmış ürünler için eklendi.
        //Soft delete için IsDeleted kullanılacak
        public bool IsActive { get; set; }

        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }
}
