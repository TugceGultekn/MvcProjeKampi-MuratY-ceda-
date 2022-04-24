using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        Context c = new Context();
       
        // GET: WriterPanel

        public ActionResult WriterProfile()
        {
            return View();
        }
     
        public ActionResult MyHeading(string p)
        {
           
            p = (string)Session["WriterMail"];
           var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
   
           var values = hm.GetListByWriter(writeridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
         
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString() //text displaymemberdır adı ister Value valuememberdır ıd ister.
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.d = writeridinfo;
            ViewBag.t = writermailinfo;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString() //text displaymemberdır adı ister Value valuememberdır ıd ister.
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
      
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading(int p=1 )
        {

            var headings = hm.GetList().ToPagedList(p, 4);
            return View(headings);
        }
        public ActionResult ToDoList()
        {
            return View();
        }

    }
}