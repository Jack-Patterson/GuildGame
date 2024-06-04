document.getElementById('fileInput').addEventListener('change', handleFileSelect);

let entries = [];
let currentEditIndex = null;

function handleFileSelect(event) {
    const file = event.target.files[0];
    if (file) {
        const reader = new FileReader();
        reader.onload = function(e) {
            const content = e.target.result;
            parseCSharpFile(content);
        };
        reader.readAsText(file);
    }
}

function parseCSharpFile(content) {
    const constructorRegex = /public\s+\w+\(([^)]*)\)/;
    const match = content.match(constructorRegex);
    if (match) {
        const params = match[1].split(',').map(param => param.trim());
        createForm(params);
    } else {
        alert("No constructor found in the provided C# file.");
    }
}

function createForm(params) {
    const formContainer = document.getElementById('formContainer');
    formContainer.innerHTML = ''; // Clear the form container
    
    params.forEach(param => {
        const [type, name] = param.split(' ');
        const div = document.createElement('div');
        div.classList.add('input-group');

        if (type.startsWith('List')) {
            const listContainer = document.createElement('div');
            listContainer.classList.add('list-container');
            listContainer.id = `${name}-container`;

            const label = document.createElement('label');
            label.textContent = name;
            label.setAttribute('for', name);

            const addButton = document.createElement('button');
            addButton.type = 'button';
            addButton.textContent = `Add ${name}`;
            addButton.addEventListener('click', () => addListItem(name));

            listContainer.appendChild(label);
            listContainer.appendChild(addButton);
            div.appendChild(listContainer);
        } else {
            const label = document.createElement('label');
            label.textContent = name;
            label.setAttribute('for', name);

            const input = document.createElement('input');
            input.type = 'text';
            input.id = name;
            input.name = name;

            div.appendChild(label);
            div.appendChild(input);
        }

        formContainer.appendChild(div);
    });

    document.getElementById('submitBtn').disabled = false; // Enable the submit button
}

function addListItem(listName) {
    const listContainer = document.getElementById(`${listName}-container`);

    const div = document.createElement('div');
    div.classList.add('input-group');

    const input = document.createElement('input');
    input.type = 'text';
    input.name = listName;

    const removeButton = document.createElement('button');
    removeButton.type = 'button';
    removeButton.textContent = 'Remove';
    removeButton.addEventListener('click', () => div.remove());

    div.appendChild(input);
    div.appendChild(removeButton);
    listContainer.appendChild(div);
}

document.getElementById('submitBtn').addEventListener('click', handleSubmit);

function handleSubmit() {
    const inputs = document.querySelectorAll('#formContainer input');
    const entry = {};

    inputs.forEach(input => {
        if (input.name.includes('List')) {
            if (!entry[input.name]) {
                entry[input.name] = [];
            }
            entry[input.name].push(input.value);
        } else {
            entry[input.name] = input.value;
        }
    });

    if (currentEditIndex !== null) {
        entries[currentEditIndex] = entry;
        currentEditIndex = null;
    } else {
        entries.push(entry);
    }

    updateEntryList();
    saveToJson();
    resetForm();
}

function updateEntryList() {
    const entryList = document.getElementById('entryList');
    entryList.innerHTML = '';

    entries.forEach((entry, index) => {
        const li = document.createElement('li');
        li.textContent = JSON.stringify(entry);
        li.addEventListener('click', () => editEntry(index));
        entryList.appendChild(li);
    });
}

function editEntry(index) {
    currentEditIndex = index;
    const entry = entries[index];
    const inputs = document.querySelectorAll('#formContainer input');

    inputs.forEach(input => {
        if (input.name.includes('List')) {
            const listContainer = document.getElementById(`${input.name}-container`);
            listContainer.innerHTML = '';

            entry[input.name].forEach(value => {
                addListItem(input.name);
                const listInputs = listContainer.querySelectorAll(`input[name=${input.name}]`);
                listInputs[listInputs.length - 1].value = value;
            });
        } else {
            input.value = entry[input.name];
        }
    });
}

function resetForm() {
    const inputs = document.querySelectorAll('#formContainer input');
    inputs.forEach(input => {
        input.value = '';
    });

    const listContainers = document.querySelectorAll('.list-container');
    listContainers.forEach(container => {
        container.innerHTML = '';
    });
}

function saveToJson() {
    const json = JSON.stringify(entries, null, 2);
    const blob = new Blob([json], { type: 'application/json' });
    const url = URL.createObjectURL(blob);

    const downloadLink = document.getElementById('downloadLink');
    downloadLink.href = url;
    downloadLink.download = 'entries.json';
    downloadLink.style.display = 'block';
}
