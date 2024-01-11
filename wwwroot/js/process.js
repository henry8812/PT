(function () {
    console.log("charged");
    getQuestions();
    getProcessQuestions(processId)
   
  

    var createQuestionsBtn = document.getElementById("createQuestionsBtn");

    createQuestionsBtn.addEventListener('click', async function () {
        // Obtener el texto de la pregunta desde el formulario
        var questionText = document.getElementById('question').value;
    
        // Crear el objeto con los datos de la pregunta y el processId
        var data = {
            Question: {
                Text: questionText
                // Agregar otros campos de la pregunta si es necesario
            },
            ProcessId: processId // Usar el valor de processId definido en otro lugar
        };
    
        // Convertir el objeto a JSON
        var jsonData = JSON.stringify(data);
    
        // Llamar a la función para crear la pregunta
        let response = await createQuestion(jsonData);
        console.log(response);
    });
    


})();
