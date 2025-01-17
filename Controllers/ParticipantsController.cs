using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECF.Data;
using ECF.Models;
using ECF.Models.ViewModels;
using ECF.Services;

namespace ECF.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly ECFContext _context;
        private StatistiquesService _statistiques;

        public ParticipantsController(ECFContext context, StatistiquesService statistiquesService)
        {
            _context = context;
            _statistiques = statistiquesService;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Participant.Include(p => p.Evenements).ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant
                .Include(e => e.Evenements)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            var evenements = _context.Evenement.ToList(); // Liste des événements
            var viewModel = new ParticipantViewModel
            {
                Evenements = evenements.Select(e => new EvenementViewModel
                {
                    EvenementId = e.Id,
                    EvenementName = e.Nom,
                    EvenementDate = e.Date,
                    EvenementLieu = e.Lieu,
                    IsSelected = false
                }).ToList()
            };
            return View(viewModel);
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipantId,ParticipantName,ParticipantFirstName,Age")] ParticipantViewModel viewModel)
        {
            Console.WriteLine(ModelState);
            if (ModelState.IsValid)
            {
                var participant = new Participant
                {
                    Nom = viewModel.ParticipantName,
                    Prenom = viewModel.ParticipantFirstName,
                    Age = viewModel.Age,
                    Evenements = viewModel.Evenements != null ? viewModel.Evenements
                        .Where(e => e.IsSelected)
                        .Select(e => new EvenementParticipant
                        {
                            EvenementId = e.EvenementId,
                            ParticipantId = viewModel.ParticipantId
                        }).ToList() : null
                };

                _context.Participant.Add(participant);
                await _context.SaveChangesAsync();

                var stat = new Statistiques
                {
                    StatistiqueName = "Nombre participants",
                    Data = _context.Participant.Count()
                };
                await _statistiques.CreateAsync(stat);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Age")] Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.Id))
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
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participant = await _context.Participant.FindAsync(id);
            if (participant != null)
            {
                _context.Participant.Remove(participant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participant.Any(e => e.Id == id);
        }
    }
}
