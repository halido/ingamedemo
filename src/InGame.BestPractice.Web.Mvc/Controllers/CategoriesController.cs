using System;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using InGame.BestPractice.Authorization;
using InGame.BestPractice.Controllers;
using InGame.BestPractice.Store;
using InGame.BestPractice.Web.Models.Account;
using InGame.BestPractice.Web.Models.Store;
using Microsoft.AspNetCore.Mvc;

namespace InGame.BestPractice.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Categories)]
    public class CategoriesController : BestPracticeControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public async  Task<ActionResult> Index()
        {
            var categories =await _categoryAppService.GetAll(new PagedResultRequestDto()
            {
                MaxResultCount = 200
            });
            var categoriesHierarchical =await _categoryAppService.GetAllHierarchical(new PagedResultRequestDto()
            {
                MaxResultCount = 200
            });
            return View(new CategoryListViewModel()
            {
                Categories = categories.Items,
                CategoriesHierarchical = categoriesHierarchical.Items
            });
        }
        public async Task<ActionResult> EditCategoryModal(int categoryId)
        {
            var category = await _categoryAppService.Get(new EntityDto(categoryId));
            var categories = (await _categoryAppService.GetAll(new PagedAndSortedResultRequestDto() { MaxResultCount = Int32.MaxValue })).Items;
            var model = new EditCategoryModalViewModel()
            {
                Category = category,
                Categories = categories
            };
            return View("_EditCategoryModal", model);
        }
    }
}