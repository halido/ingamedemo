using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using InGame.BestPractice.Controllers;

namespace InGame.BestPractice.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BestPracticeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
