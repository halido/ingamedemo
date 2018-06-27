using Abp.AutoMapper;
using InGame.BestPractice.Sessions.Dto;

namespace InGame.BestPractice.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
