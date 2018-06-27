using Abp.Application.Services;
using Abp.Application.Services.Dto;
using InGame.BestPractice.Store.Dto;

namespace InGame.BestPractice.Store
{
    public interface IProductAppService :  IAsyncCrudAppService<ProductDto, int, PagedResultRequestDto,
        CreateProductDto, ProductDto>
    {

    }
}