const uri = 'api/CandidatApi';
let $candidats = $("#candidats");
//SignalR--------------------
var connection = new signalR.HubConnectionBuilder().withUrl("/candidatHub").build(); 
//SignalR--------------------

function getCandidats() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get candidats.', error));
}

 //----------------AddCandidat---------------------
 
 //------------------------------------------------

  //----------------PutCandidat---------------------
 //------------------------------------------------


  //----------------DeleteCandidat---------------------
 //------------------------------------------------

 connection.on("CandidatChange", () => {
  getCandidats();
});

connection.start().catch(err => console.error("SignalR Connection Error: ", err));

function _displayItems(data) {
  //_displayCount(data.length);
  $candidats.empty();
  data.forEach(candidat => {
    let template = `<tr>
        <td>${candidat.candidatId}</td>
        <td>${candidat.nom}</td>
        <td><img width="100px" height="100px" src="images/${candidat.logo}" alt="Logo du candidat" /></td>
        <td>${candidat.libelleVote ? candidat.libelleId : 'N/A'}</td>
        <td>${candidat.libelleVote ? candidat.libelleVote : 'N/A'}</td>
        <td>
            <a href="/Candidats/Edit/${candidat.candidatId}">Edit</a> |
            <a href="/Candidats/Details/${candidat.candidatId}">Details</a>
            <a href="/Candidats/Delete/${candidat.candidatId}">Delete</a>
        </td>
    </tr>`;
    $candidats.append($(template));
});
  
}