window.addEventListener('DOMContentLoaded', (event) => {
  getVisitCount();
});

const functionApi = 'https://getresumecounterhttp.azurewebsites.net/api/HttpTrigger1?code=lkfOCHSjqDT-W3ktyGnTyGk7NQjJkUcINK7UvGfHm2OIAzFu5Xh3gQ=='; 

const getVisitCount = () => {
  let count = 0;
  fetch(functionApi, {
      mode: 'cors',
  })
  .then(response => {
      return response.json()
  })
  .then(res => {
      const count = res;
      document.getElementById('counter').innerText =count;
  })
  return count;
}