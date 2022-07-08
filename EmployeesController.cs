using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BOL;
using BLL;


namespace DBWebMVCAPP.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> employees = HRManager.GetAll();
            return View(employees);
        }
        public ActionResult Details(int id)
        {
            Employee employee = HRManager.GetByID(id);
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            bool status = HRManager.Delete(id);
            return RedirectToAction("index");
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(int id, string name, string designation,double salary)
        {
            Employee emp = new Employee
            {
                ID = id,
                Name = name,
                Designation = designation,
                Salary = salary
            };
            HRManager.Insert(emp);
            return RedirectToAction("index");

        }

        public ActionResult Update(int id)
        {
            Employee employee = HRManager.GetByID(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(int id, string name, string designation,double salary)
        {
            Employee emp = new Employee
            {
                 ID = id,
                Name = name,
                Designation = designation,
                Salary = salary
            };
            HRManager.Update(emp);
            return RedirectToAction("index");
        }
    }
}

 