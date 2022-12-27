using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Domain.Entities;
using TMS.Infrastructure.Repositories;

namespace TMS.Web.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ReferenceRepository _referenceRepo;

        public ReferenceController(ReferenceRepository referenceRepo)
        {
            _referenceRepo = referenceRepo;
        }

        // GET: Reference
        public async Task<IActionResult> Index()
        {
              return View(await _referenceRepo.GetAllAsync());
        }

        // GET: Reference/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var reference = await _referenceRepo.GetByIdAsync(id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: Reference/Create
        public IActionResult Create()        
        {
            var model = new Reference();
            return View(model);
        }

        // POST: Reference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reference reference)
        {
            if (ModelState.IsValid)
            {
                reference.CreatedBy = 1;
                await _referenceRepo.CreateAsync(reference);
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }

        // GET: Reference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var reference = await _referenceRepo.GetByIdAsync(id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);
        }

        // POST: Reference/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reference reference)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Reference? oldRef = await _referenceRepo.GetByIdAsync(id);
                    var test = await _referenceRepo.GetAllAsync();
                    var test1 = await _referenceRepo.GetAsync(x => x.ReferenceID == id);
                    if(oldRef != null)
                    {
                        reference.CreatedOn = oldRef.CreatedOn;
                        reference.CreatedBy = oldRef.CreatedBy;
                    }

                    reference.UpdatedBy = 2;
                    await _referenceRepo.UpdateAsync(reference);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }

        // GET: Reference/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var reference = await _referenceRepo.GetByIdAsync(id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: Reference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var test = await _referenceRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
