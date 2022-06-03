using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApp.DB.DbOperations;
using MyApp.Model.Properties;
namespace MyApplication.Controllers
{
    public class HomeController : Controller
    {
        EmpRepos er = new EmpRepos();
        // GET: Home
        public ActionResult Index()
        {
            EmpRepos er = new EmpRepos();
            int id = er.M1();
            ViewBag.ids = id;
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
               
                int id = er.AddEmployee(model);
                ViewBag.ids = "Data with Employee Id" + id + "added";
            }
            return View();

        }
        public ViewResult GetAllEmployees()
        {
            var emplsit =  er.GetAllEmployees();
            return View(emplsit);
        }
        public ViewResult Details(int id)
        {
            var emp = er.GetEmployee(id);
            return View(emp);
        }
        public ActionResult Edit(int id)
        {
            var emp = er.GetEmployee(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(EmpModel model)
        {
            if (ModelState.IsValid)
            {
                er.UpdateEmployee(model);
                return RedirectToAction("GetAllEmployees");
            }
            return View();
        }
     
        public ActionResult Delete(int id)
        {
            er.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployees");
        }
        
    }
}     