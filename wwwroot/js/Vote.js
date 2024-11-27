const uri = '/api/VoteApi';
let $votes = $("#votes");

function getVotes() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get votes.', error));
}

function addVote() {
  const votant = document.getElementById('votant');
  const candidatId = document.getElementById('candidatId');

  const vote = {
    votant: votant.value.trim(),
    candidatId: candidatId
  };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(vote)
  })
    .then(response => response.json())
    .then(() => console.log())
    .catch(error => console.error('Unable to add vote.', error));
}

function deleteVote(id) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => console.log("le vote a été supprimé correctement"))
  .catch(error => console.error('Unable to delete item.', error));
}


function updateVote() {
  const voteId = document.getElementById('edit-id').value;
  const votant = document.getElementById('votant');
  const candidatId = document.getElementById('candidatId');

  const vote = {
    voteId : parseInt(voteId, 10),
    votant: votant.value.trim(),
    candidatId: parseInt(candidatId, 10),
  };

  fetch(`${uri}/${voteId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(vote)
  })
  .then(() => console.log())
  .catch(error => alert('Unable to update item.' + error));

  

  return false;
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
function _displayItems(data) {

  //_displayCount(data.length);

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