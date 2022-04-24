using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = adminmanager.GetList();
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminmanager.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = adminmanager.GetbyID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
           adminmanager.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}