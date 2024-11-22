using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Models;

namespace VoteFCSoccer.Data
{
    public class MvcVoteCandidatContext : DbContext
    {
        public MvcVoteCandidatContext (DbContextOptions<MvcVoteCandidatContext> options)
            : base(options)
        {
        }

        public DbSet<VoteFCSoccer.Models.Candidat> Candidat { get; set; } = default!;
        public DbSet<VoteFCSoccer.Models.Vote> Vote { get; set; } = default!;
        public DbSet<VoteFCSoccer.Models.LibelleVote> LibelleVote { get; set; } = default!;
    }
}
