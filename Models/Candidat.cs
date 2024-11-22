using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VoteFCSoccer.Models;
public class Candidat
{

[Display(Name = "ID")]
public int CandidatId { get; set; }
public string? Nom { get; set; }
public string? Logo { get; set; }


[ForeignKey("LibelleVote")]
public int LibelleId { get; set; }
public LibelleVote? LibelleVote { get; set; }

public ICollection<Vote>? Votes { get; set; }






}