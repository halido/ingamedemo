using Microsoft.AspNetCore.Antiforgery;
using InGame.BestPractice.Controllers;

namespace InGame.BestPractice.Web.Host.Controllers
{
    public class AntiForgeryController : BestPracticeControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
