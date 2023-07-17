using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikMvcAppTestSwitch.Models;

namespace TelerikMvcAppTestSwitch.Controllers
{
    public class SwitchTestController : Controller
    {
        // GET: SwitchTest
        public ActionResult Index()
        {
            var model = new SwitchTestViewModel();
            model.someString = "sample Name";
            model.someBool = true;

            return View(model);
        }

        public ActionResult AddNew()
        {
            var model = new SwitchTestViewModel();
            model.someString = "new Name";
            model.someBool = false;

            return View(model);
        }
    }
}