const uri = '/api/LibelleVoteApi';
let $libelleVotes = $("#libelleVotes");
//SignalR--------------------
var connection = new signalR.HubConnectionBuilder().withUrl("/libelleVoteHub").build(); 
//SignalR--------------------
function getLibelleVotes() {
  // Start the connection.
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get libelleVotes.', error));
}


connection.on("LibelleVoteChange", () => {
  getLibelleVotes();
});

connection.start().catch(err => console.error("SignalR Connection Error: ", err));



function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'libelleVote' : 'libelleVotes';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {

  //_displayCount(data.length);
  $libelleVotes.empty(); 
  data.forEach(libelleVote => {
    // Votre logique de création de template ici
    let template = `<tr>
      <td>${libelleVote.libelleId}</td>
      <td>${libelleVote.libelle}</td>
      <td>
        <a href="/LibelleVotes/Edit/${libelleVote.libelleId}">Modifier</a> |
        <a href="/LibelleVotes/Delete/${libelleVote.libelleId}">Supprimer</a> |
        <a href="/LibelleVotes/Details/${libelleVote.libelleId}">Détails</a> 
      </td>
    </tr>`;
    
      
      $libelleVotes.append($(template));         
    
  });

}