using VoteFCSoccer.Models;

public class CandidatViewModel
{
    public int CandidatId { get; set; }
public string? Nom { get; set; }
public string? Logo { get; set; }
public int LibelleId { get; set; }
public string LibelleVote { get; set; } 

public ICollection<Vote>? Votes { get; set; }
    
    
}