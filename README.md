# billyDotNet

BillyDotNet es un algoritmo que obitiene el número de facturas para un id determinado para un id seleccionado.

# Caracteristicas

Tiene métodos para obtener el numéro de facturas de un id por diferentes periodos de tiempo.
- Anual
- Mensual
- Quincenal
- Semanal*

> **Nota: el  método semanal es capáz de sacar facturas en un periodo determinado de tiempo, las peticiones que se hacen se dividen en forma semanal tomando como una semana el periodo de tiempo de lunes a domingo.**

### ¿Cómo probarlo?

En la carpeta stable del repositorio se encuentra la última versión estable. Solo es necesario hacer doble click sobre el ejecutable para correrlo. Es necesario tener instalado .Net Framework 4.5.

El proyecto está hecho en Visual Studio 2017, ésta es la versión recomendada para abrir el proyecto. Visual Studio 2015 también es compatible, aunque es posible que los proyectos de pruebas de integración como unitarias no puedan ser cargados.

Para probar el proyecto solo es necesario en darle "iniciar" al proyecto "billyDotNet" dentro de Visual Studio, el IDE por lo general realiza la descarga de los paquetes NuGet utilizados en la aplicación. Esta es la lista de paquetes utilizados en los diferentes proyectos.

|                      | billyDotNet | billyDotNet.Test.Integration | billyDotNet.Test.Unit |
|----------------------|-------------|------------------------------|-----------------------|
| Castle.Core          |     N/A     |             4.0.0            |         4.0.0         |
| Moq                  |     N/A     |            4.7.25            |         4.7.25        |
| MSTest.TestAdapter   |     N/A     |            1.1.11            |         1.1.11        |
| MSTest.TestFramework |     N/A     |            1.1.11            |         1.1.11        |

### ¿Cómo funciona?

Para obtener las facturas anuales de un id, el algoritmo intenta obtener primero las facturas por mes en una sola petición. Si la petición arroja "más de 100 resultados", divide el mes en quincenas y vuelve a intentar la petición, ahora por quincenas. Si aún nos sigue arrojando "más de 100 resultados", las quincenas se dividen en semanas de lunes a domingo, haciendo peticiones ahora por cada semana obtenida. Si al final se obtienen "más de 100 resultados" se intenta hacer la petición por día.
