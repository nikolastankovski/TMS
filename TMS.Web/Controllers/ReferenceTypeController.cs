using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMS.Domain.DTO;
using TMS.Domain.Entities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Services;

namespace TMS.Web.Controllers
{
    public class ReferenceTypeController : Controller
    {
        private readonly ReferenceTypeService _refTypeService;

        public ReferenceTypeController(ReferenceTypeService refTypeService)
        {
            _refTypeService = refTypeService;
        }

        // GET: ReferenceType
        public async Task<IActionResult> Index()
        {
              return View(await _refTypeService._refTypeRepo.GetAllAsync());
        }

        // GET: ReferenceType/Create
        public IActionResult Create()
        {
            var model = _refTypeService.GetReferenceModel();
            return View(model);
        }

        // POST: ReferenceType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReferenceType referenceType, List<DTO_Language> languages)
        {
            _refTypeService.Create(referenceType, languages);
            return RedirectToAction(nameof(Index));
        }

        // GET: ReferenceType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var model = _refTypeService.GetReferenceModel(id);

            return View(model);
        }

        // POST: ReferenceType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReferenceType referenceType, List<DTO_Language> languages)
        {
            _refTypeService.Edit(referenceType, languages);
            return RedirectToAction(nameof(Index));
        }
    }
}
