using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCData.Models;

namespace MVCData.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model =
                 from p in _people
                 orderby p.City
                 select p;
            return View(model);
        }
        public ActionResult List()
        {
            var model =
                from p in _people
                select p;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Person model = _people.SingleOrDefault(x => x.Id == Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Person modded)//int Id,FormCollection collection
        {
            try
            {
                Person model = _people.SingleOrDefault(x => x.Id == modded.Id);
                model.Name = modded.Name;
                model.Cellphone = modded.Cellphone;
                model.City = modded.City;
                model.Country = modded.Country;
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Person modded)
        {
            try
            {
                _people.Add(modded);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Person person = _people.SingleOrDefault(x => x.Id == Id);
            return View(person);
        }

        public ActionResult Delete(Person modded)
        {
            try
            {
                Person person = _people.SingleOrDefault(x => x.Id == modded.Id);
                _people.Remove(person);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }

        }
        public ActionResult FilterN()
        {
            var model =
                from p in _people
                orderby p.Name
                select p;
            return View(model);
        }
        public ActionResult FilterC()
        {
            var model =
                from p in _people
                orderby p.City
                select p;
            return View(model);
        }
        //*****************************************************
        public ActionResult AjaxPost()
        {
            return PartialView();
        }
        //*****************************************************

        static List<Person> _people = new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Wassim",
                Cellphone = "073591 0453",
                City = "Stockholm",
                Country="Sweden"
            },
            new Person
            {
                Id = 2,
                Name = "Andre",
                Cellphone = "072591 0453",
                City = "Paris",
                Country="France"
            },
            new Person
            {
                Id = 3,
                Name = "Stev",
                Cellphone = "071591 0453",
                City = "London",
                Country="England"
            },
            new Person
            {
                Id = 4,
                Name = "Mike",
                Cellphone = "070591 0453",
                City = "Ottawa",
                Country="Canada"
            },
            new Person
            {
                Id = 5,
                Name = "Ulf",
                Cellphone = "074591 0453",
                City = "D.C",
                Country="USA"
            },
            new Person
            {
                Id = 6,
                Name = "Sokoban",
                Cellphone = "078591 0453",
                City = "Tokyo",
                Country="Japan"
            },new Person
            {
                Id = 7,
                Name = "Jörgan",
                Cellphone = "079591 0453",
                City = "Oslo",
                Country="Norway"
            },
        };
    }
}