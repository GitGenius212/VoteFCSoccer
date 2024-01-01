using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VoteFCSoccer.Models;

namespace VoteFCSoccer.Data
{
    public class MvcVoteEquipeContext : DbContext
    {
        public MvcVoteEquipeContext (DbContextOptions<MvcVoteEquipeContext> options)
            : base(options)
        {
        }

        public DbSet<VoteFCSoccer.Models.Equipe> Equipe { get; set; } = default!;
        public DbSet<VoteFCSoccer.Models.Vote> Vote { get; set; } = default!;
        public DbSet<VoteFCSoccer.Models.LibelleVote> LibelleVote { get; set; } = default!;
    }
}
