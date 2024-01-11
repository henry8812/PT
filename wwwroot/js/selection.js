let languages = [];

const applicantsTemplate = `
<table id="selectionTable" class="table table-striped table-bordered">
    <thead>
        <tr>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Email</th>
            <th>Nombre del proceso</th>
            <th>Nivel del proceso</th>
            <th>Estado</th>
            <th>Resultado de la prueba</th>
            <th>Número de pruebas</th>
            <th>Detalles</th>
        </tr>
    </thead>
    <tbody>
        {{#each this}}
            <tr>
                <td>{{Applicant.User.FirstName}}</td>
                <td>{{Applicant.User.LastName}}</td>
                <td>{{Applicant.User.Email}}</td>
                <td>{{Process.Name}}</td>
                <td>{{Process.Level.Name}}</td>
                <td>{{Status.Name}}</td>
                <td>{{TestResult}}</td>
                <td>{{ApplicantProcesses.length}}</td>
                <td><a href="/applicants/{{Applicant.UserId}}" class="btn btn-success">Ver detalles</a></td>
            </tr>
        {{/each}}
    </tbody>
</table>
`;

const loadSelections = async () => {
    let data = await getSelections();

    // Si el dato recibido es un array, puede pasarse directamente a la plantilla
    const source = applicantsTemplate;
    const template = Handlebars.compile(source);
    const processHTML = template(data);

    // Insertar el HTML generado en el DOM
    const catalogElement = $('#table');
    catalogElement.html(processHTML);

    // Inicializar la tabla utilizando DataTables
    $('#selectionTable').DataTable({
        // Habilitar funcionalidad de filtrado para cada columna
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var select = $('<select class="form-select"><option value=""></option></select>')
                    .appendTo($(column.header()))
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex($(this).val());
                        column.search(val ? '^' + val + '$' : '', true, false).draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>');
                });
            });
        }
    });
};

// ONREADY FUNCTION TO LOAD ALL THE DATA ON THE SCREEN
$(document).ready(function () {
    console.log("charged");
    loadSelections();
});
