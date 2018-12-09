using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFBll;
using EFModel;
namespace WebApp.Controllers
{
    public class IndexController : Controller
    {
        NewInfoBll newInfoBll = new NewInfoBll();
        NewTypesBll typeBll = new NewTypesBll();
        // GET: Index
        public ActionResult Index()
        {
            ViewData.Model = newInfoBll.GetList(5,1);
            return View();
        }

        /// <summary>
        /// get添加信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            var list1 = typeBll.GetList(10, 1).ToList();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (NewTypes item in list1)
            {
                list.Add(new SelectListItem {
                    Text = item.News.NewsConent,
                    Value = item.News.NewsId.ToString()
                });
            }
            ViewBag.typeList = list;
            return View();
        }
    }
}