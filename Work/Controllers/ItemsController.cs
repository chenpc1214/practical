using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Work.Data;
using Work.Models;
using X.PagedList;

namespace Work.Controllers
{
    public class ItemsController : Controller
    {
        private readonly WorkContext _context;

        public ItemsController(WorkContext context)
        {
            _context = context;
        }
        public IActionResult Panel() 
        {
            return View();
        
        }
        // GET: Items
        public async Task<IActionResult> Index(int pg=1)
        {
            List<Item> products = _context.Item.ToList();

            const int pageSize = 10;

            if (pg < 1) {pg = 1;}

            int MyCount = products.Count();

            var pager = new Pager(MyCount, pg, pageSize);

            int SkipRow = (pg - 1) * pageSize;

            var data = products.Skip(SkipRow).Take(pager.PageSize).ToListAsync();

            this.ViewBag.Pager = pager;

            return PartialView(await data);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Mobile,sth")] Item item)
        {
            string status = "NO";
            if (ModelState.IsValid)
            {
                status = "OK";
                _context.Add(item);
                await _context.SaveChangesAsync();
                return Content(JsonConvert.SerializeObject(status));
            }
            return Content(JsonConvert.SerializeObject(status));
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Mobile,sth")] Item item)
        {
            string status = "NO";

            if (id != item.Id)
            {
                status = "NotFound";

                return Content(JsonConvert.SerializeObject(status));
            }

            if (ModelState.IsValid)
            {
                status = "OK";

                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Content(JsonConvert.SerializeObject(status));
            }
            return Content(JsonConvert.SerializeObject(status));
        }

        // POST: Items/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            string status = "NO";

            var item = await _context.Item.FindAsync(id);

            if (item != null) {

                status = "OK";
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
                return Content(JsonConvert.SerializeObject(status));
            }

            return Content(JsonConvert.SerializeObject(status));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}
