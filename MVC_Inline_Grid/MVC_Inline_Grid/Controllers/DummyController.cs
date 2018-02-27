﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Inline_Grid.Models;

namespace MVC_Inline_Grid.Controllers
{
    public class DummyController : Controller
    {
        List<DummyModel> lst = new List<DummyModel> { new DummyModel() { ID = 1, FirstName = "John", LastName = "Doe" } };

        // GET: Dummy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DummyData()
        {
            //lst.Add(new DummyModel() { ID = 1, FirstName = "John", LastName = "Doe" });
            return View(lst);
        }
        [HttpPost]
        public ActionResult EditDummyData(int ID,string FirstName,string LastName)
        {
            if (lst.Where(x => x.ID == ID).FirstOrDefault() != null)
            {
                lst.Where(x => x.ID == ID).First().FirstName = FirstName;
                lst.Where(x => x.ID == ID).First().LastName = LastName;
                return Json(lst,JsonRequestBehavior.AllowGet);
            }
            else return null;
        }
    }
}