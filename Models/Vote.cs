using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VoteFCSoccer.Models;
public class Vote
{

[Display(Name = "ID")]
public int voteId { get; set; }
public string? Votant { get; set; }


[ForeignKey("Equipe")]
public int EquipeId { get; set; }
public Equipe? Equipe { get; set; }



}