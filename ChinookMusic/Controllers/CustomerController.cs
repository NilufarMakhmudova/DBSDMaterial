using ChinookMusic.DAL;
using ChinookMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChinookMusic.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            IList<Customer> cusList = new List<Customer>();
            CustomerRepository repo = new CustomerRepository();
            cusList = repo.GetAllCustomers();
            return View(cusList);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            CustomerRepository repo = new CustomerRepository();
            Customer cust = repo.GetCustomerById(id);
            return View(cust);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            CustomerRepository cusRepo = new CustomerRepository();
            cusRepo.CreateCustomer(cus);
            return RedirectToAction("Index");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            CustomerRepository repo = new CustomerRepository();
            Customer c = repo.GetCustomerById(id);
            return View(c);
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind(Include = "CustomerId")]Customer cust)
        {
            CustomerRepository repo = new CustomerRepository();
            repo.DeleteCustomer((int)cust.CustomerId);
            return RedirectToAction("Index");
        }
    }
}
