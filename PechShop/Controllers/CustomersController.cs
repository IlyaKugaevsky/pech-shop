using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PechShop.Data;
using PechShop.Models;
using PechShop.Services;
using PechShop.ViewModels;

namespace PechShop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly PechShopContext _context;
        private readonly OrderService _orderService;

        public CustomersController(PechShopContext context)
        {
            _context = context;
            _orderService = new OrderService(_context);
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.Include(c => c.Orders).ThenInclude(o => o.Product).ToListAsync();
            var viewModels = customers.Select(c => new CustomerViewModel(c));
            return View(viewModels);
        }

        public async Task<IActionResult> CreateOrder(int? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var products = await _context.Products.ToListAsync();

            return View(new OrderForCustomerToCreateViewModel(customer, products));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder([Bind("SelectedProductId, CustomerId, ProductsNumber")] OrderForCustomerToCreateViewModel orderForCustomerToCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _orderService.CreateOrder(
                    orderForCustomerToCreateViewModel.SelectedProductId,
                    orderForCustomerToCreateViewModel.CustomerId,
                    orderForCustomerToCreateViewModel.ProductsNumber);

                return RedirectToAction("Index");
            }
            return View(orderForCustomerToCreateViewModel);
        }

        public async Task<IActionResult> ShowOrders(int? customerId)
        {
            if (customerId == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.Include(c => c.Orders).ThenInclude(o => o.Product).SingleOrDefaultAsync(m => m.Id == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return View(new CustomerOrdersViewModel(new CustomerViewModel(customer), customer.Orders));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,AdditionalInfo")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,AdditionalInfo")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(m => m.Id == id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
