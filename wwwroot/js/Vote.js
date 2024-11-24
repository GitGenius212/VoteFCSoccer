const uri = 'api/VoteApi';
let $votes = $("#votes");

function getVotes() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get votes.', error));
}
/* 
function addItem() {
  const addNameTextbox = document.getElementById('add-name');

  const item = {
    isComplete: false,
    name: addNameTextbox.value.trim()
  };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
    .then(response => response.json())
    .then(() => {
        getVotes();
      addNameTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => getVotes())
  .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
  const item = votes.find(item => item.id === id);
  
  document.getElementById('edit-name').value = item.name;
  document.getElementById('edit-id').value = item.id;
  document.getElementById('edit-isComplete').checked = item.isComplete;
  document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
  const itemId = document.getElementById('edit-id').value;
  const item = {
    id: parseInt(itemId, 10),
    isComplete: document.getElementById('edit-isComplete').checked,
    name: document.getElementById('edit-name').value.trim()
  };

  fetch(`${uri}/${itemId}`, {
    method: 'PUT',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(item)
  })
  .then(() => getVotes())
  .catch(error => console.error('Unable to update item.', error));

  closeInput();

  return false;
}

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