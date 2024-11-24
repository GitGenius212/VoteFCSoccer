const uri = 'api/CandidatApi';
let $candidats = $("#candidats");

function getCandidats() {
  fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error('Unable to get candidats.', error));
}

/* function addItem() {
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
        getCandidats();
      addNameTextbox.value = '';
    })
    .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
  fetch(`${uri}/${id}`, {
    method: 'DELETE'
  })
  .then(() => getCandidats())
  .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
  const item = candidats.find(item => item.id === id);
  
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
  .then(() => getCandidats())
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
} */

function _displayItems(data) {
  //_displayCount(data.length);

  data.forEach(candidat => {
    let template = `<tr>
        <td>${candidat.candidatId}</td>
        <td>${candidat.nom}</td>
        <td><img width="100px" height="100px" src="images/${candidat.logo}" alt="Logo du candidat" /></td>
        <td>${candidat.libelleVote ? candidat.libelleId : 'N/A'}</td>
        <td>${candidat.libelleVote ? candidat.libelleVote : 'N/A'}</td>
        <td>
            <a href="/Equipes/Edit/${candidat.candidatId}">Edit</a> |
            <a href="/Equipes/Details/${candidat.candidatId}">Details</a>
            <a href="/Equipes/Delete/${candidat.candidatId}">Delete</a>
        </td>
    </tr>`;
    $candidats.append($(template));
});
  
}