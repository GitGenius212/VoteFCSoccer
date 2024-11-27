using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Data;
using VoteFCSoccer.Models;

namespace VoteFCSoccer.Controllers
{
    public class CandidatsController : Controller
    {
        private readonly MvcVoteCandidatContext _context;

        public CandidatsController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: Candidats
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: Candidats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidat
                .Include(e => e.LibelleVote)
                .FirstOrDefaultAsync(m => m.CandidatId == id);
            if (candidat == null)
            {
                return NotFound();
            }
            
            var votes = from v in _context.Vote
                        select v;
            
            votes = votes.Where(s => s.CandidatId == candidat.CandidatId);

            candidat.Votes = await votes.ToListAsync();

            if(candidat.Votes == null)
                candidat.Votes = default!;

            return View(candidat);
        }

        // GET: Candidats/Create
        public IActionResult Create()
        {
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle");
            return View();
        }

        

        // GET: Candidats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidat.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }
            ViewData["LibelleId"] = new SelectList(_context.Set<LibelleVote>(), "LibelleId", "Libelle", candidat.LibelleId);
            return View(candidat);
        }

        

        // GET: Candidats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidat
                .Include(e => e.LibelleVote)
                .FirstOrDefaultAsync(m => m.CandidatId == id);
            if (candidat == null)
            {
                return NotFound();
            }

            return View(candidat);
        }

        
    }
}
