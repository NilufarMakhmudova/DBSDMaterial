using ChinookMusic.DAL;
using ChinookMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChinookMusic.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IList<Employee> empList = new List<Employee>();
            EmployeeRepository empRepo = new EmployeeRepository();
            empList = empRepo.GetAllEmployees();
            return View(empList);

        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            empRepo.CreateEmployee(emp);
            return RedirectToAction("Index");
        }


        #region Edit Employee
        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            Employee emp = empRepo.GetEmployeeById(id);
            ViewBag.ReportsToOptions = empRepo.GetAllEmployees();
            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            //empRepo.UpdateEmployee(emp);
            empRepo.UpdateEmployeeStoredProc(emp);
            return RedirectToAction("Index");
        }
        #endregion

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
