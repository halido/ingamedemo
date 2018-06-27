using System.Collections.Generic;
using InGame.BestPractice.Store.Dto;

namespace InGame.BestPractice.Web.Models.Store
{
    public class EditCategoryModalViewModel
    {
        public CategoryDto Category { get; set; }

        public IReadOnlyList<CategoryDto> Categories { get; set; }


    }
}