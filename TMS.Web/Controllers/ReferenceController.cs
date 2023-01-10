using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create()
        {
            var model = await _refService.GetModelAsync();
            return View(model);
        }

        // POST: Reference/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reference reference, List<DTO_Language> languages)
        {

            var create = await _refService.CreateAsync(reference, languages);

            return RedirectToAction(nameof(Index));
        }

        // GET: Reference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var model = await _refService.GetModelAsync(referenceId: id);

            return View(model);
        }

        // POST: Reference/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reference reference, List<DTO_Language> languages)
        {
            var update = await _refService.EditAsync(reference, languages);

            return RedirectToAction(nameof(Index));
        }
    }
}
