const url = "http://localhost:5190/api/Ordenacao/";

let valuesX = [];
let bubbleSort = [];
let selectionSort = [];
let insertSort = [];
let quickSort = [];
let textSorted = "";
let header = {
  "Content-Type": "application/json",
  accept: "*/*",
};

document.getElementById("form").addEventListener("submit", (e) => {
  e.preventDefault();
  let formData = new FormData(form);
  let text = document.getElementById("textToSort").value;
  valuesX.push(text.length);

  let body = {
    textToSort: text,
  };
  generateChart(body);
});

async function getApiData(body) {
  await getBubbleSort(body);
  await getSelectionSort(body);
  await getInsertSort(body);
  await getQuickSort(body);
}

async function getBubbleSort(body) {
  let json = await getData(url + "BubbleSort", body, header);
  bubbleSort.push(json.duration);
}

async function getSelectionSort(body) {
  let json = await getData(url + "SelectionSort", body, header);
  selectionSort.push(json.duration);
  textSorted = json.textSorted;
}

async function getInsertSort(body) {
  let json = await getData(url + "InsertionSort", body, header);
  insertSort.push(json.duration);
}

async function getQuickSort(body) {
  let json = await getData(url + "QuickSort", body, header);
  quickSort.push(json.duration);
}

async function getData(url, body, header) {
  let response = await fetch(url, {
    body: JSON.stringify(body),
    method: "POST",
    headers: header,
  });
  if (response.status == 200) {
    return await response.json();
  }
  console.log(response);
  return null;
}

async function generateChart(body) {
  await getApiData(body);
  let canva = document.getElementById("myChart");
  canva.style = {
    display: "block",
  };

  new Chart("myChart", {
    type: "line",
    data: {
      labels: valuesX,
      datasets: [
        {
          label: "Bubble Sort",
          data: bubbleSort,
          borderColor: "red",
          fill: false,
        },
        {
          label: "Selection Sort",
          data: selectionSort,
          borderColor: "green",
          fill: false,
        },
        {
          label: "Insertion Sort",
          data: insertSort,
          borderColor: "blue",
          fill: false,
        },
        {
          label: "Quick Sort",
          data: quickSort,
          borderColor: "gray",
          fill: false,
        },
      ],
    },
  });
  // generateParagraph();
}

function generateParagraph() {
  let div = document.getElementById("sorted");
  let p = document.getElementById("textSorted");
  // p.innerHTML = textSorted;

  // cria um novo elemento div
  const newH2 = document.createElement("h2");

  // e adiciona algum conteúdo ao elemento
  const newContent = document.createTextNode("Texto ordenado:");

  // adiciona o "text node" para o div recém criado
  newH2.appendChild(newContent);

  div.insertBefore(newH2, p);

  console.log(div);
}
