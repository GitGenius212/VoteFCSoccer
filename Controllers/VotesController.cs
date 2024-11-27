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
    public class VotesController : Controller
    {
        private readonly MvcVoteCandidatContext _context;

        public VotesController(MvcVoteCandidatContext context)
        {
            _context = context;
        }

        // GET: Votes
        public async Task<IActionResult> Index()
        {

            return View();
        }

        // GET: Votes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.Candidat)
                .FirstOrDefaultAsync(m => m.voteId == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        // GET: Votes/Create
        public IActionResult Create()
        {
            ViewData["CandidatId"] = new SelectList(_context.Candidat, "CandidatId", "Nom");
            return View();
        }

        // GET: Votes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }
            ViewData["CandidatId"] = new SelectList(_context.Candidat, "CandidatId", "Nom", vote.CandidatId);
            return View(vote);
        }

        

        // GET: Votes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vote = await _context.Vote
                .Include(v => v.Candidat)
                .FirstOrDefaultAsync(m => m.voteId == id);
            if (vote == null)
            {
                return NotFound();
            }

            return View(vote);
        }

        
    }
}
