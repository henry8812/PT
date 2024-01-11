// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const handleLogin = async()=>{
  let username = document.querySelector("#username").value;
  let password = document.querySelector("#password").value;

  let response = JSON.parse(await login(username, password));
  

  if(response.token !== undefined){
    sessionStorage.setItem("JWT", response.token);
    const tokenPayload = JSON.parse(atob(response.token.split('.')[1]));
    authUser = tokenPayload;
    location.href = "/"
  }
  console.log(response);
  return response;
}

let loginForm = document.querySelector("#loginForm");
if(loginForm){
  loginForm.addEventListener("submit", async(event) => {
    event.preventDefault(); // Prevenir el envío por defecto del formulario
    handleLogin(); // Llamar a la función handleLogin
   //stable
  });
}

