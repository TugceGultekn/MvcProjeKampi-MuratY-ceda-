using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MvcProjeKampi.Controllers
{
    
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetbyID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetbyID(id);
            return View(values);
               
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messagevalidator.Validate(p);
            if (results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}