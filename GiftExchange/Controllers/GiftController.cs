using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiftExchange.Services;
using GiftExchange.Models;

namespace GiftExchange.Controllers
{
    public class GiftController : Controller
    {
        // GET: Gift
        public ActionResult Index()
        {
            return View(GiftServices.GetAllGifts());
        }

        public ActionResult DeleteGift(int id) 
        {
            GiftServices.DeleteGift(id);
            return RedirectToAction("Index");
        }

        public ActionResult OpenGift(int id)
        {
            return View(GiftServices.OpenGift(id));
        }

        public ActionResult AreYouSure(int id)
        {
            return View(GiftServices.GetOneGift(id));
        }

        //TODO: create new gift
        public ActionResult CreateNew()
        {
            return View();
        }

        //TODO: update gift
        public ActionResult UpdateGift(int id)
        {
            return View();
        }
    }
}