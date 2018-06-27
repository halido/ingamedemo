using Abp.AutoMapper;
using InGame.BestPractice.Authentication.External;

namespace InGame.BestPractice.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
