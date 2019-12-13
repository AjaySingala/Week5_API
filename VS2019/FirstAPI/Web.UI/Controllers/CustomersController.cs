using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class CustomersController : Controller
    {
        private static List<Customer> _customers = new List<Customer>()
        {
            new Customer { Id = 101, Firstname = "John", Lastname = "Smith" },
            new Customer { Id = 102, Firstname = "Mary", Lastname = "Jane" },
            new Customer { Id = 103, Firstname = "Joe", Lastname = "Guy" }
        };

        private static CustomerList _customersList;

        public CustomersController()
        {
            if (_customersList == null)
            {
                _customersList = new CustomerList();
                _customersList.Customers.Add("John");
                _customersList.Customers.Add("Mary");
                _customersList.Customers.Add("Joe");
                _customersList.Customers.Add("David");
            }
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View(_customersList.Customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View(_customersList);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerList customers)
        //public ActionResult Create(IFormCollection collection)
        {
            var names = Request.Form["Customers"].ToString().Split(',');
            for (int i = 1; i < names.Length; i++)
            {
                _customersList.Customers.Add(names[i]);
            }
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}