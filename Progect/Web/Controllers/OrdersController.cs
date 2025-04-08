using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YourNamespace.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrdersController (ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Orders.ToList());
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        public IActionResult Create()
        {
            ViewBag.Users=new SelectList(_context.Users.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(int id, Order order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (existingOrder == null) return NotFound();

            existingOrder.UserId = order.UserId;
            existingOrder.Final_sum = order.Final_sum;
            existingOrder.Status_orders = order.Status_orders;
            existingOrder.Date_order = order.Date_order;
            existingOrder.Date_end = order.Date_end;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

