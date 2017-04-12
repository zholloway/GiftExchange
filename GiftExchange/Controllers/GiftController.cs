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
        [HttpGet]
        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(FormCollection collection)
        {
            GiftServices.CreateGift(collection);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateGift(int id)
        {
            return View(GiftServices.GetOneGift(id));
        }

        [HttpPost]
        public ActionResult UpdateGift(int id, FormCollection collection)
        {
            GiftServices.EditGift(id, collection);
            return RedirectToAction("Index");
        }

    }
}