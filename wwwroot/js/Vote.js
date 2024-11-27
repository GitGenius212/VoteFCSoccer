const uri = '/api/VoteApi';
let $votes = $("#votes");
//SignalR--------------------
var connection = new signalR.HubConnectionBuilder().withUrl("/voteHub").build(); 
//SignalR--------------------
function getVotes() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get votes.', error));
}

/*
function closeInput() {
  document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'to-do' : 'to-dos';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}
 */

connection.on("VoteChange", () => {
  getVotes();
});

connection.start().catch(err => console.error("SignalR Connection Error: ", err));

function _displayItems(data) {

  //_displayCount(data.length);
  $votes.empty();
  data.forEach(vote => {
    // Votre logique de création de template ici
    let template = `<tr>
      <td>${vote.voteId}</td>
      <td>${vote.votant}</td>
      <td>${vote.candidat.candidatId}</td>
      <td>${vote.candidat.nom}</td>
      <td><img width="100px" height="100px" src="images/${vote.candidat.logo}" alt="Logo du candidat" /></td>
      <td>
        <a href="/Votes/Edit/${vote.voteId}">Edit</a> |
        <a href="/Votes/Delete/${vote.voteId}">Delete</a>
        <a href="/Votes/Details/${vote.voteId}">Details</a>
      </td>
    </tr>`;
    $votes.append($(template));
  });

}