using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VoteFCSoccer.Models;
public class Vote
{

[Display(Name = "ID")]
public int voteId { get; set; }
public string? Votant { get; set; }


[ForeignKey("Candidat")]
public int CandidatId { get; set; }
public Candidat? Candidat { get; set; }



}