using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PechShop.Data;
using PechShop.Models;
using PechShop.ViewModels;

namespace PechShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PechShopContext _context;

        public OrdersController(PechShopContext context)
        {
            _context = context;

            //var order = new Order()
            //{
            //    CustomerId = 1,
            //    ProductId = 1,
            //    Date = DateTime.Now,
            //    ProductsNumber = 5
            //};

            //_context.Add(order);
            //_context.SaveChanges();
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            var customers = await _context.Customers.ToListAsync();
            var products = await _context.Products.ToListAsync();

            var viewModel = new OrderViewModel(customers, products);

            return View(viewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SelectedProductId, SelectedCustomerId, ProductsNumber")] OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    CustomerId = orderViewModel.SelectedCustomerId,
                    ProductId = orderViewModel.SelectedProductId,
                    ProductsNumber = orderViewModel.ProductsNumber,
                    Date = DateTime.Now
                };


                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderViewModel);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.ToListAsync();
            var products = await _context.Products.ToListAsync();

            var viewModel = new OrderViewModel(customers, products, order);

            return View(viewModel);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,CustomerId,ProductsNumber,Date")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
