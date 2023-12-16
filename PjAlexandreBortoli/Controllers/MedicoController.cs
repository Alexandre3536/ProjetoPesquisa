using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PjAlexandreBortoli.Data.EF;
using PjAlexandreBortoli.Data.Interface;
using PjAlexandreBortoli.Models;

namespace PjAlexandreBortoli.Controllers
{
    public class MedicoController : Controller
    {
        private IMedicoRepository medicoRepository;

        public MedicoController(
           IMedicoRepository _medicoRepo
        )
        {
            medicoRepository = _medicoRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(medicoRepository.GetMedicos());
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Medico? m = medicoRepository.GetMedicoById(id.Value);

            if (m == null)
                return NotFound();

            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    medicoRepository.Update(medico);
                    return View("Index", medicoRepository.GetMedicos());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Medico? m = medicoRepository.GetMedicoById(id.Value);
            if (m == null)
                return NotFound();

            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            medicoRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Medico m)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    medicoRepository.Create(m);
                    return View("Index", medicoRepository.GetMedicos());
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View();
        }
    }
}
