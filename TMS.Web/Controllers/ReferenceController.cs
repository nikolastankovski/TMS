using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TMS.Application.Interfaces.Repositories;
using TMS.Domain.DTO;
using TMS.Domain.Entities;
using TMS.Infrastructure.Services;

namespace TMS.Web.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ReferenceService _refService;

        public ReferenceController(ReferenceService refService)
        {
            _refService = refService;
        }

        // GET: Reference
        public async Task<IActionResult> Index()
        {
              return View(await _refService._refRepo.GetAllAsync());
        }

        // GET: Reference/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var reference = await _refService._refRepo.GetByIdAsync(id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: Reference/Create
        public IActionResult Create()
        {
            var model = _refService.GetReferenceModel();
            return View(model);
        }

        // POST: Reference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reference reference, List<DTO_Language> languages)
        {

            //_refService.Create(reference, languages);
            /*if (ModelState.IsValid)
            {
                _refService._refRepo.Create(reference);
                return RedirectToAction(nameof(Index));
            }*/
            return View(reference);
        }

        // GET: Reference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var reference = await _refService._refRepo.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ReferenceID,ReferenceTypeId,Code,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,IsActive")] Reference reference)
        {
            if (id != reference.ReferenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _refService._refRepo.UpdateAsync(reference);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }
    }
}
