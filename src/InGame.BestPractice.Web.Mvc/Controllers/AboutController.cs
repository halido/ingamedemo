using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using InGame.BestPractice.Controllers;

namespace InGame.BestPractice.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BestPracticeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
