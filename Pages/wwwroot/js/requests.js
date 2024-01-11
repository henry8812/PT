// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const login = async(username, password) => {
    return new Promise(resolve => {
        var data = JSON.stringify({
            "username": username,
            "password": password
          });
          
          var xhr = new XMLHttpRequest();
          xhr.withCredentials = true;
          
          xhr.addEventListener("readystatechange", function() {
            if(this.readyState === 4) {
              console.log(this.responseText);
            }
          });
          
          xhr.open("POST", "https://localhost:7208/Auth/login");
          xhr.setRequestHeader("Content-Type", "application/json");
          
          xhr.send(data);
    })
}
