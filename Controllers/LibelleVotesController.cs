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
    public class LibelleVotesController : Controller
    {
        private readonly MvcVoteCandidatContext _context;

        public LibelleVotesController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: LibelleVotes
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: LibelleVotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libelleVote = await _context.LibelleVote
                .FirstOrDefaultAsync(m => m.LibelleId == id);
            if (libelleVote == null)
            {
                return NotFound();
            }

            var equipes = from e in _context.Candidat
                          select e;

            equipes = equipes.Where(s => s.LibelleId == libelleVote.LibelleId);
            libelleVote.Candidats = await equipes.ToListAsync();

            if(libelleVote.Candidats == null)
                libelleVote.Candidats = default!;


            return View(libelleVote);
        }

        // GET: LibelleVotes/Create
        public IActionResult Create()
        {
            return View();
        }

        

        // GET: LibelleVotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libelleVote = await _context.LibelleVote.FindAsync(id);
            if (libelleVote == null)
            {
                return NotFound();
            }
            return View(libelleVote);
        }

        

        // GET: LibelleVotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libelleVote = await _context.LibelleVote
                .FirstOrDefaultAsync(m => m.LibelleId == id);
            if (libelleVote == null)
            {
                return NotFound();
            }

            return View(libelleVote);
        }

        
    }
}
