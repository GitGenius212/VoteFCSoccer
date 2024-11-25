const uri = 'api/LibelleVoteApi';
let $libelleVotes = $("#libelleVotes");

function getLibelleVotes() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get libelleVotes.', error));
}

function addLibelleVote() {
  const libelle = document.getElementById('libelle');

  const libelleVote = {
    libelle : libelle
  };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(libelleVote)
  })
    .then(response => response.json())
    .then(() => {
        getLibelleVotes();
      addNameTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

function deleteLibelleVote(id) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => console.log(""))
  .catch(error => console.error('Unable to delete item.', error));
}

function updateLibelleVote() {
  const LibelleVoteId = document.getElementById('edit-id').value;
  const libelleVote = {
    libelleId: parseInt(LibelleVoteId, 10),
    libelle: document.getElementById('libelle').value.trim()
  };

  fetch(`${uri}/${LibelleVoteId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(libelleVote)
  })
  .then(() => console.log())
  .catch(error => console.error('Unable to update libelleVote.', error));


  return false;
}



function _displayCount(itemCount) {
  const name = (itemCount === 1) ? 'libelleVote' : 'libelleVotes';

  document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {

  //_displayCount(data.length);

  data.forEach(libelleVote => {
    // Votre logique de création de template ici
    let template = `<tr>
      <td>${libelleVote.libelleId}</td>
      <td>${libelleVote.libelle}</td>
      <td>
        <a href="/LibelleVotes/Edit/${libelleVote.libelleId}">Edit</a> |
        <a href="/LibelleVotes/Delete/${libelleVote.libelleId}">Delete</a>
        <a href="/LibelleVotes/Details/${libelleVote.libelleId}">Details</a>
      </td>
    </tr>`;
    $libelleVotes.append($(template));
  });

}