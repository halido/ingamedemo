using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using InGame.BestPractice.Authorization;
using InGame.BestPractice.Controllers;
using InGame.BestPractice.Store;
using InGame.BestPractice.Web.Models.Store;
using InGame.BestPractice.Web.Models.Users;

namespace InGame.BestPractice.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Products)]
    public class ProductsController : BestPracticeControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly CategoryAppService _categoryAppService;

        public ProductsController(IProductAppService productAppService, CategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _categoryAppService = categoryAppService;
        }
        public async Task<IActionResult> Index()
        {
            var products = (await _productAppService.GetAll(new PagedResultRequestDto() { MaxResultCount = Int32.MaxValue })).Items; // Paging not implemented yet
            var categories = (await _categoryAppService.GetAll(new PagedResultRequestDto() { MaxResultCount = Int32.MaxValue })).Items;// Paging not implemented yet

            var model = new ProductListViewModel()
            {
                Products = products,
                Categories = categories
            };

            return View(model);

        }
        public async Task<ActionResult> EditProductModal(int productId)
        {
            var product = await _productAppService.Get(new EntityDto(productId));
            var categories = (await _categoryAppService.GetAll(new PagedAndSortedResultRequestDto(){MaxResultCount = Int32.MaxValue})).Items;
            var model = new EditProductModalViewModel
            {
                Product = product, 
                Categories = categories
            };
            return View("_EditProductModal", model);
        }

        public async Task<ActionResult> Preview(string slug, int id)
        {
            var product = await _productAppService.Get(new EntityDto(id));

            return View(product);
        }


    }
}