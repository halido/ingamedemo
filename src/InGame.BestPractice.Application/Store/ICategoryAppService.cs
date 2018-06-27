using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using InGame.BestPractice.Authorization;
using InGame.BestPractice.MultiTenancy.Dto;
using InGame.BestPractice.Roles.Dto;
using InGame.BestPractice.Store.Dto;

namespace InGame.BestPractice.Store
{
  
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, int, PagedResultRequestDto, CreateCategoryDto, CategoryDto>
    {

        Task<PagedResultDto<CategoryDto>> GetAllHierarchical(PagedResultRequestDto input);
    }
}
