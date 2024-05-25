using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarWashApp.Data;
using CarWashApp.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CarWashApp.Controllers
{
    public class CarWashServicesController : Controller
    {
        private readonly CarWashContext _context;

        public CarWashServicesController(CarWashContext context)
        {
            _context = context;
        }

        // GET: CarWashServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarWashServices.ToListAsync());
        }

        // GET: CarWashServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carWashService = await _context.CarWashServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carWashService == null)
            {
                return NotFound();
            }

            return View(carWashService);
        }

        // GET: CarWashServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarWashServices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] CarWashService carWashService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carWashService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carWashService);
        }

        // GET: CarWashServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carWashService = await _context.CarWashServices.FindAsync(id);
            if (carWashService == null)
            {
                return NotFound();
            }
            return View(carWashService);
        }

        // POST: CarWashServices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] CarWashService carWashService)
        {
            if (id != carWashService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carWashService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarWashServiceExists(carWashService.Id))
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
            return View(carWashService);
        }


        // GET: CarWashServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carWashService = await _context.CarWashServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carWashService == null)
            {
                return NotFound();
            }

            return View(carWashService);
        }

        // POST: CarWashServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carWashService = await _context.CarWashServices.FindAsync(id);
            _context.CarWashServices.Remove(carWashService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarWashServiceExists(int id)
        {
            return _context.CarWashServices.Any(e => e.Id == id);
        }


          // GET: YourController/Index

        // GET: YourController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

   

        // GET: YourController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // GET: YourController/Delete/5
        // public IActionResult Delete(int id)
        // {
        //     return View();
        // }

        // GET: YourController/Book/5
        public IActionResult Book(int id)
        {
            return View();
        }
        
    }
}
