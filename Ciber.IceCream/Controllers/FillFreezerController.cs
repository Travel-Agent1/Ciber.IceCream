﻿using System.Web.Mvc;

namespace CiberIs.Controllers
{
    [Authorize(Roles = "admin")]
    public class FillFreezerController : Controller
    {
        public ActionResult AddNew()
        {
            return View();
        }
    }
}
