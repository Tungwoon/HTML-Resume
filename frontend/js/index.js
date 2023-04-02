window.addEventListener('DOMContentLoaded',(event) => {
  getVisitCount();
})

const functionApi = 'https://getresumehttpcounter.azurewebsites.net/api/HttpTrigger1?code=OPfJtv5gOZfKxn5nbchTvvyRrVAaQPuSxPv8N80jmI6UAzFuS7wVqA=='; 


const getVisitCount = () => {
  let count = 30
  fetch(functionApi).then(Response => {
    return Response.json()
  }).then (Response =>{
    console.log ("Website called function API.");
    count = Response.count;
    document.getElementById("counter").innerText = count;
  }).catch(function(error){
    console.log(error);
  });
  return count;
}


