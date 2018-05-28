using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        /// <summary> 
        /// 主页的qhj 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {   
            return View( ); 
        }
        /// <summary> 
        /// 修改页的qhj
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}