using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using InGame.BestPractice.Authorization;
using InGame.BestPractice.Collection;
using InGame.BestPractice.MultiTenancy.Dto;
using InGame.BestPractice.Store.Dto;

namespace InGame.BestPractice.Store
{

    //AsyncCrudAppService CRUD operasyonlarını içermektedir.
    [AbpAuthorize(PermissionNames.Pages_Categories)]
    public class CategoryAppService
        : AsyncCrudAppService<Category, CategoryDto, int, PagedResultRequestDto, CreateCategoryDto, CategoryDto>, ICategoryAppService
    {
        public CategoryAppService(IRepository<Category, int> repository) : base(repository)
        {
        }

        public  async Task<PagedResultDto<CategoryDto>> GetAllHierarchical(PagedResultRequestDto input)
        {
            CheckGetAllPermission();

            var query = CreateFilteredQuery(input);

            query = query.Where(f => f.ParentCategoryId.HasValue == false);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);
            var allSubCategories =
                await AsyncQueryableExecuter.ToListAsync(Repository.GetAll().Where(f => f.ParentCategoryId.HasValue));

            entities =  entities.Traverse(category => allSubCategories.Where(f => f.Id == category.ParentCategoryId)).ToList();

            return new PagedResultDto<CategoryDto>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
          
        }

        protected override void MapToEntity(CategoryDto updateInput, Category entity)
        {
            entity.Name = updateInput.Name;
            if(entity.Id != updateInput.ParentCategoryId) //Kendini parentı yapamaz
            entity.ParentCategoryId = updateInput.ParentCategoryId;
            entity.Description = updateInput.Description;
        }
    }
}