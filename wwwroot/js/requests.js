let authUser = null;
let questions = [];
let processQuestions = []

const login = async (username, password) => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("POST", "/Auth/login", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      resolve(xhr.response)
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    let data = JSON.stringify({ username: username, password: password });
    xhr.send(data);
  })

};

const createProcess = async (data) => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("POST", "/process/create", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      Swal.fire({
        title: "Creacion exitosa",
        text: "Haz creado correctamente la prueba de seleccion!",
        icon: "success"
      }).then(x => {
        location.reload();
      })
      resolve(xhr.response)
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    
    xhr.send(data);
  })

};
const createQuestion = async (data) => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("POST", "/questions/create", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      Swal.fire({
        title: "Creacion exitosa",
        text: "Haz creado correctamente la pregunta!",
        icon: "success"
      }).then(x => {
        location.reload();
      })
      resolve(xhr.response)
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    
    xhr.send(data);
  })

};



const getQuestions = async () => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("GET", "/questions/all", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      questions = JSON.parse(xhr.response);
      resolve(JSON.parse(xhr.response))
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    xhr.send();
  })

};

const getProcessQuestions = async (processId) => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("GET", `/questions/process/${processId}`, true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      processQuestions = JSON.parse(xhr.response);
      resolve(JSON.parse(xhr.response))
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    xhr.send();
  })

};


const getProcesses = async () => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("GET", "/process/all", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      resolve(JSON.parse(xhr.response))
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    xhr.send();
  })

};

const getApplicants = async () => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("GET", "/applicants/all", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      resolve(JSON.parse(xhr.response))
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    xhr.send();
  })

};
const getSelections = async () => {
  return new Promise( resolve => {
    let xhr = new XMLHttpRequest();
    xhr.open("GET", "/selections/all", true);
    xhr.setRequestHeader("Content-Type", "application/json");
    
    xhr.onload = function() {
      console.log(xhr.status, xhr)
      if (xhr.status === 200) {
        console.log(xhr.response)
        console.log(xhr.responseText);
      } else {
        console.error('Error:', xhr.status);
      }
      resolve(JSON.parse(xhr.response))
    };
    
    xhr.onerror = function() {
      console.error('Request failed');
    };
    
    xhr.send();
  })

};




const isJWTValid = () => {
  let jwt = sessionStorage.getItem("JWT");

  if (jwt) {
    const tokenPayload = JSON.parse(atob(jwt.split('.')[1])); // Decodificar el token JWT
    
    const expirationTimeInSeconds = tokenPayload.exp; // Obtener la fecha de expiración del token
    const currentTimestampInSeconds = Math.floor(Date.now() / 1000); // Obtener el timestamp actual en segundos
    
    return expirationTimeInSeconds > currentTimestampInSeconds; // Verificar si el token sigue siendo válido
  }
  
  return false; // Si no hay token o hubo algún error, retornar falso
};


if(!isJWTValid()){
  sessionStorage.clear();
  let login = location.href.indexOf("/login") !== -1
  if(!login){
    location.href = "/login"

  }
}