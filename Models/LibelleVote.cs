
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VoteFCSoccer.Models;
public class LibelleVote
{
[Key]
[Display(Name = "ID")]
public int LibelleId { get; set; }
public string? Libelle { get; set; }

public ICollection<Equipe>? Equipes { get; set; }

}