using Abp.MultiTenancy;
using InGame.BestPractice.Authorization.Users;

namespace InGame.BestPractice.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
