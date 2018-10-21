using CustomerManagementSys.Models;
using CustomerManagementSys.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SpendCheck.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var lst = new Customer(_context).GetAllCustomersWithMembership();
            return View(lst);
        }

        public List<Customer> GetCustomers()
        {
            var lst = new Customer(_context).GetAllCustomersWithMembership();
            return lst;
        }

        public ActionResult New()
        {
            var membershipTypes = new MembershipType(_context).GetAllMembershipTypes();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            var membershipTypes = new MembershipType(_context).GetAllMembershipTypes();

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = membershipTypes
                };

                return View("CustomerForm", viewModel);
            }

            bool didSave = new Customer(_context).SaveCustomer(customer);

            // check if saved in db successfully
            return RedirectToAction("Index", "Customers");

        }

        public ActionResult Details(int id)
        {
            var customer = new Customer(_context).GetCustomerWithMembership(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = new Customer(_context).GetCustomer(id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}