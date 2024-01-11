let languages = [];
const processTemplate = `
<div class="row">
    {{#each this}}
        <div class="col-md-4 mb-4">
            <div class="card">
                <div class="card-body">
                    <h3 class="card-title">{{Name}}</h3>
                    <p class="card-text">Fehca Inicial:     {{StartDate}}</p>
                    <p class="card-text">Fecha Final:       {{EndDate}}</p>
                    <p class="card-text">Lenguaje:          {{Language.Name}}</p>
                    <p class="card-text">Nivel:             {{Level.Name}}</p>
                    
                    
                    <p class="card-text">Cantidad Preguntas:{{Questions.length}}</p>
                    <p class="card-text">Cantidad aspirantes:{{ApplicantProcesses.length}}</p>
                    
                    <a class="btn btn-success mx-auto" href="/process/{{ProcessId}}">Ver detalles</a>

                </div>
            </div>
        </div>
    {{/each}}
</div>

`;
const loadProcesses = async () => {
    let data = await getProcesses();
    console.log(data)

    // Si el dato recibido es un array, puede pasarse directamente a la plantilla
    const processHTML = Handlebars.compile(processTemplate)(data);

    // Insertar el HTML generado en el DOM
    const catalogElement = document.getElementById('catalog');
    catalogElement.innerHTML = processHTML;
};



// ONREADY FUNCTION TO LOAD ALL THE DATA ON THE SCREEN
(function () {
    console.log("charged");
    loadProcesses();
  
    var boton = document.getElementById('botonCrearPrueba');

    // Agregar un evento de clic al botón
    boton.addEventListener('click', function () {
        // Mostrar el modal al hacer clic en el botón
        $('#crearPruebaModal').modal('show');
    });
    document.getElementById('guardarBtn').addEventListener('click', async function () {
        // Obtener los valores del formulario
        var nombre = document.getElementById('nombrePrueba').value;
        var descripcion = document.getElementById('descripcionPrueba').value;
        var startDate = document.getElementById('startDate').value;
        var endDate = document.getElementById('endDate').value;
        var languageId  = document.getElementById('languageSelect').value;

        // Crear un objeto con los datos
        var data = {
            name: nombre,
            description: descripcion,
            startDate: startDate,
            endDate: endDate,
            languageId : languageId
            // ...otros campos si los hay
        };
        console.log(data)

        // Convertir el objeto a JSON
        var jsonData = JSON.stringify(data);
        let response = await createProcess(jsonData);
    });


})();
