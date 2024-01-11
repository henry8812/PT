let languages = [];
const applicantsTemplate = `
<div class="row">
    {{#each this}}
        <div class="col-md-4 mb-4">
            <div class="card">
                <div class="card-body">
                <h3 class="card-title">{{User.FirstName}} {{User.LastName}}</h3>
                <p>Email:   {{User.Email}}</p>
                <p>Pruebas: {{ApplicantProcesses.length}}</p>
              
                    <a class="btn btn-success mx-auto" href="/applicants/{{userId}}">Ver detalles</a>

                </div>
            </div>
        </div>
    {{/each}}
</div>

`;
const loadApplicants = async () => {
    let data = await getApplicants();
    console.log(data)

    // Si el dato recibido es un array, puede pasarse directamente a la plantilla
    const processHTML = Handlebars.compile(applicantsTemplate)(data);

    // Insertar el HTML generado en el DOM
    const catalogElement = document.getElementById('catalogApplicants');
    catalogElement.innerHTML = processHTML;
};



// ONREADY FUNCTION TO LOAD ALL THE DATA ON THE SCREEN
(function () {
    console.log("charged");
    loadApplicants();
})();
