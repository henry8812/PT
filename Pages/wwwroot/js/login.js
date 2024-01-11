// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const handleLogin = async()=>{
  let username = document.querySelector("#username").value;
  let password = document.querySelector("#password").value;

  let response = await login(username, password);
  console.log(response);
  return response;
}

let loginForm = document.querySelector("#loginForm");
loginForm.addEventListener("submit", async(event) => {

  let loginResponse = await handleLogin(); // Llamar a la función handleLogin
  event.preventDefault(); // Prevenir el envío por defecto del formulario
});
