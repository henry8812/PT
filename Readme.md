
# ASPIRANTE
- Nombre:   Henry A. Gomez M.
- Celular:  3104155557
- Email:    henry8812@gmail.com 

```
Con el presente repositorio hago entrega de la prueba tecnica de .NET, teniendo en cuenta la prueba a continuacion documento la entrega.
```

## Modelo de Datos

Se construyeron diferentes modelos para este proyecto, los principales solicitados en la prueba son los siguientes:
asdasd
### Aspirante
- Datos básicos
- Datos de contacto
- Pruebas de selección con su respectivo estado (Registrada, En Proceso, Terminada o Anulada)
- Calificación o resultado de la prueba (soportar valores decimales, 0 a 100).

### Prueba de Selección
- Nombre o Descripción
- Aspirante
- Fecha de inicio
- Fecha de finalización (No puede ser menor a la fecha de inicio)
- Tipo de prueba (técnica o práctica)
- Lenguaje de programación a evaluar
- Cantidad de preguntas
- Nivel (Junior, Middle y Senior)
- Preguntas que componen la prueba

En /Backend/Models seencontraran los siguientes modelos:
- Answer.cs               --  Creada con la finalidad de almacenar las respuestas de los aspirantes, sin uso debido a que esto no esta descrito en las funcionalidades
- Applicant.cs            --  Este modelo es el que corresponde al aspirante
- ApplicantProcess.cs     --  Este modelo representa el proceso de seleccion de un aspirante, en este se puede ver el estado, el resultado entre otros atributos 
- Category.cs             --  Este modelo podria representar la categoria de los procesos de seleccion, dado que no hay una funcionalidad relacionda en la prueba solo esta definido, no tiene uso
- Language.cs             --  Este modelo representa los lenguajes de programacion, este esta relacionado a las pruebas de seleccion
- Level.cs                --  Este modelo representa el nivel de las pruebas de seleccion 
- Location.cs             --  Este modelo podria represnetar la ubicacion de la oferta laboral, actualmente sin uso
- Option.cs               --  Este modelo podria represnetar las opciones de respuesta para las preguntas que podrian llegar a ser de seleccion con opciones
- Process.cs              --  Este modelo representa las pruebas de seleccion
- Question.cs             --  Este modelo representa las preguntas
- QuestionType.cs         --  Este modelo podria representar los tipos de preguntas, actualmente sin uso.
- Role.cs                 --  Este modelo representa los roles, hereda de identityRole
- Status.cs               --  Este modelo representa los diferentes estados de los procesos de seleccion de los aspirantes.
- TestType.cs             --  Este modelo representa los tipo de prueba de seleccion tecnica o practica, podria haber mas tipos por eso se creo una tabla
- User.cs                 --  Este modelo representa los usuarios, hereda de identityUser

### Crear Datos Semilla
- 10 aspirantes 
- 15 pruebas de selección (Diferentes tipos y niveles) con sus respectivas preguntas
Los datos anteriores se encontraran en un archivo DDL.sql en la raiz del proyecto junto con el PT01.bak
Para las pruebas si se usa el respaldo
{
    "username" : "adminadmin",
    "password" : "Admin123+"
}


## Back-End
- Construir API's RESTful que implementen los servicios CRUD de la aplicación (Aspirantes y Pruebas de Selección).
-- Se construyo un API rest, que permite hacer las diferentes consultas para los modelos. estos se encuentra en el directorio /Backend/Controllers
- Construir un endpoint para la generación y exportación del reporte (archivo plano) con la información de las pruebas de selección por cada aspirante, utilizando la información que retorna el procedimiento almacenado creado en el punto anterior. El archivo plano debe quedar alojado en una carpeta dentro de la aplicación.
```
Respecto a este procedimiento almacenado en el punto anterior no menciona un proceso almancenado esto solo se menciona aqui, fue algo que no se implemento.
```


## Front-End
- Implementar ASP.Net Identity para gestionar los usuarios de la aplicación, ya que solo un usuario autenticado puede utilizar las funcionalidades (CRUD's y Reporte).
```
Tuve problemas durante la implementacion del identity para que desde el frontend se manejara el identity y la gestion de usuarios,
por esto el identity solo se uso para la creacion de las API's de login y registro.
El frontend tiene una validacion constante que determina si el JWT enviado por el login es valido y de esta manera exige el login nuevamente.
```

- Construir una interfaz que permita gestionar los aspirantes consumiendo las API RESTful (CRUD) respectivas.
```
Se contruyo la interfaz que lista los aspirantes
```

- Construir una interfaz que permita gestionar las pruebas de selección por cada aspirante consumiendo las API RESTful (CRUD) respectivas.
```
Se construyo la intefaz para la visualizacion de las pruebas de seleccion, y ademas una para el detalle de cada una de ella, desde donde se puede crear preguntas asociadas a cada prueba de seleccion.
```

- Construir una opción o funcionalidad que permita invocar (Consumir) el API RESTful para la generación del archivo plano.
```
No se implemento, no era claro el tema de la generacion de que tipo de archivo se necesitaba generar.
```

Se implemento el frontend con peticiones XHR para llamar las API Rest expuestas en el backend, ademas se uso handlebars para renderizar algunas pantallas del frontend.
Se uso Bootstrap como framework css 
