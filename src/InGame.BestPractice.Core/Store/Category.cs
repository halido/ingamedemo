using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace InGame.BestPractice.Store
{
   public class Category:AuditedEntity, IDeletionAudited
    {
        public const int MaxNameLength = 255;
        public const int MaxDescriptionLength = 1024 * 1024;



        [MaxLength(MaxNameLength)]
        [Required]
        public string Name { get; set; }
        [MaxLength(MaxDescriptionLength)]
        [Required]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }

        public Category ParentCategory { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<Category> SubCategories { get; set; }
    }

    
}
