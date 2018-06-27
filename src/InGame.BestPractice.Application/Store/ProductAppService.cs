using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using InGame.BestPractice.Authorization;
using InGame.BestPractice.Store.Dto;
using InGame.BestPractice.Web;

namespace InGame.BestPractice.Store
{
    [AbpAuthorize(PermissionNames.Pages_Products)]
    public class ProductAppService
        : AsyncCrudAppService<Product, ProductDto, int, PagedResultRequestDto, CreateProductDto, ProductDto>, IProductAppService
    {
        public ProductAppService(IRepository<Product, int> repository) : base(repository)
        {
        }

        protected override Product MapToEntity(CreateProductDto createInput)
        {
            var entity = base.MapToEntity(createInput);
            //Slug oluşturmada dublicate oluşabilir fakat unique olma zorunluluğu yok
            entity.Slug = StringHelper.UrlFriendly(createInput.Name);

            return entity;
        }

        public override Task<PagedResultDto<ProductDto>> GetAll(PagedResultRequestDto input)
        {
            return base.GetAll(input);
        }

        protected override async Task<Product> GetEntityByIdAsync(int id)
        {
            var entity = await  base.GetEntityByIdAsync(id);
            this.Repository.EnsurePropertyLoaded(entity,f=>f.Category);
            return entity;
        }

        protected override IQueryable<Product> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(f => f.Category);
        }

        protected override void MapToEntity(ProductDto updateInput, Product entity)
        {
            entity.Name = updateInput.Name;
            entity.CategoryId = updateInput.CategoryId;
            entity.Description = updateInput.Description;
            entity.ImageUrl = updateInput.ImageUrl;
            entity.Price = updateInput.Price;
            entity.Slug = StringHelper.UrlFriendly(updateInput.Name);
            entity.IsActive = updateInput.IsActive;
            //Slug oluşturmada dublicate oluşabilir fakat unique olma zorunluluğu yok
        }
    }
}