﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PechShop.Data;
using PechShop.Models;
using PechShop.ViewModels;
using PechShop.Heplers;
using PechShop.Services;

namespace PechShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PechShopContext _context;
        private readonly OrderService _orderService;

        public OrdersController(PechShopContext context)
        {
            _context = context;
            _orderService = new OrderService(_context);
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.Customer).Include(o => o.Product).ToListAsync();
            var viewModels = orders.Select(o => new OrderViewModel(o)).ToList();
            return View(viewModels);
        }


        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            var customers = await _context.Customers.ToListAsync();
            var products = await _context.Products.ToListAsync();

            var viewModel = new OrderToUpdateViewModel(customers, products);

            return View(viewModel);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SelectedProductId, SelectedCustomerId, ProductsNumber")] OrderToUpdateViewModel orderToUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                //var productId = orderToUpdateViewModel.SelectedProductId;
                //var customerId = orderToUpdateViewModel.SelectedCustomerId;
                //var productsNumber = orderToUpdateViewModel.ProductsNumber;
                //var dateTime = DateTime.Now;

                //var duplicateOrder = await _context.FindDuplicateOrder(productId, customerId);

                //if (duplicateOrder == null)
                //{
                //    var order = new Order()
                //    {
                //        CustomerId = customerId,
                //        ProductId = productId,
                //        ProductsNumber = productsNumber,
                //        Date = dateTime
                //    };

                //    _context.Add(order);
                //    await _context.SaveChangesAsync();
                //}
                //else
                //{
                //    duplicateOrder.ProductsNumber += productsNumber;
                //    duplicateOrder.Date = dateTime;
                //    await _context.SaveChangesAsync();
                //}


                await _orderService.CreateOrder(
                    orderToUpdateViewModel.SelectedProductId,
                    orderToUpdateViewModel.SelectedCustomerId, 
                    orderToUpdateViewModel.ProductsNumber);

                return RedirectToAction("Index");
            }
            return View(orderToUpdateViewModel);
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
            var viewModel = new OrderToUpdateViewModel(customers, products, order);

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
            else
            {
                return RedirectToAction(nameof(Edit), order.Id);
            }
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
