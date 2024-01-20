# Ionos Updater 

Ionos Updater es un proyecto desarrollado en .NET y C# bajo los principios de Clean Architecture.
Aplicando los principios SOLID, la finalidad es mantener actualizada la dirección IP pública de tu red en el registrador de dominios (IONOS). Este sistema establece conexión con la API de Ionos para gestionar la actualización de la IP tanto del dominio como de todos sus subdominios asociados. Además, notifica al usuario a través de mensajes en Telegram una vez completada la actualización. Pipeline con GitHub Workflow configurado para facilitar el despliegue de la solución con Docker pasando tests (Moq) y subiendo la imagen en Docker Hub

## Estructura de la solución 

- **Data Access Layer:** Capa de acceso a datos.
  - **Data Access:** Acceso a datos.
  - **Entities:** Entidades.

- **Domain Layer:** Capa de dominio.
  - **Domain Service:** Lógica de negocio.
  - **Domain Contracts:** Interfaces & Adapters.

- **Infraestructure Layer:** Capa de infraestructura.
  - **Factories:** Factorías (HttpClientFactory, TelegramService...).

- **Presentation Layer:** Capa de presentación.
  - **WebAPI:** Front-End web con OpenAPI (Swagger)

- **Tests:** Capa de Tests.
  - **Domain Tests:** Tests de capa de dominio
  - **Data Access Tests:** Tests de capa de acceso a datos

- **docker:** Archivos relacionados con la construcción de imágenes Docker.
  - **Dockerfile:** Archivo de configuración para la construcción de la imagen.

- **scripts:** Scripts y utilidades.
  - **update-ip.sh:** Script para actualizar la dirección IP.

- **docs:** Documentación del proyecto.

- **.github/workflows:** Archivos de flujo de trabajo de GitHub.
  - **build-docker-image.yml:** Flujo de trabajo para construir la imagen Docker automáticamente.

- **appsettings.json:** Configuración de la aplicación.

- **README.md:** Este archivo de documentación.

## Ejecutando la solución

Para poder ejecutar la solución y poder conectar tanto con la API de IONOS como enviar mensajes hacia Telegram,necesitarás las respectivas claves de las API's. Cómo crear una clave de API en IONOS para activar el acceso a la API, o cómo crear un bot en Telegram y un chat con tu servidor escapa del "scope" de esta guía.
Para ello, puedes visitar mi blog (https://blog.carloscurtido.es), donde encontrarás una guía paso a paso de cómo hacerlo. 
Una vez tengas las claves de las API's, debes crear un archivo appsettings.json en el proyecto Ubuntu.Server.API y copiar este contenido:

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ApiKeys": {
    "Telegram": "tu_api_key_de_telegram",
    "IonosApiKey": "tu_api_key_de_ionos"
  },
  "AllowedHosts": "*"
}
```
Cambia "tu_api_key_de_telegram" y "tu_api_key_de_ionos" por las claves de tus APIS y ya estarás listo para comenzar

## Build

Ejecuta `dotnet build -tl` para hacer build de la solucion.

## Run

Para iniciar la aplicación:

```bash
cd .\Ubuntu.Server.API\
dotnet  run
```

Navega a https://localhost:9187/swagger/index.html.

## Github Actions Workflow

En la ruta /github/workflows, encontrarás el pipeline correspondiente a este proyecto. Este pipeline está configurado para que cuando se realice PR hacia master, se ejecuten los tests de la solución. En caso de fallo, denegará y cerrará la PR. En caso de que todo haya ido bien, creará una imagen de docker de la solución y la subirá a Docker Hub

Para que el pipeline funcione, debes configurar las variables SECRET en el repositorio. Ve a los Settings de tu repo y añade las tres variables necesarias:

- **DOCKER_USERNAME:** Usuario de Docker Hub
- **DOCKER_PSSWORD:** Password de Docker Hub
- **TOKEN_GITHUB:** Token de GitHub

## Test

El proyecto solo incluye (de momento) los tests funcionales.

Para ejecutar los tests:
```bash
dotnet test
```

## Metas y objetivos

El objetivo de este proyecto es reforzar y mejorar los patrones de diseño y arquitectura de software siguiendo los principios SOLID basado en el diseño orientado al dominio (DDD).
Aplicación hosteada en Docker en un servidor Ubuntu Server realizada para actualizar la IP pública del servidor en IONOS y tener siempre todos los servicios 'self-hosteados' bajo nombre de dominio/subdominio siempre online.

Aquí te dejo algunos recursos que me han parecido muy interesantes y creo que pueden ser de gran ayuda([Ardalis](https://github.com/ardalis)):

- [SOLID Principles for C# Developers](https://www.pluralsight.com/courses/csharp-solid-principles)
- [SOLID Principles of Object Oriented Design](https://www.pluralsight.com/courses/principles-oo-design) (el original, curso lago)
- [Domain-Driven Design Fundamentals](https://www.pluralsight.com/courses/domain-driven-design-fundamentals)

Si estás acostumbrado a construir aplicaciones como proyecto único o como conjunto de proyectos que siguen la arquitectura tradicional UI -> Business Layer -> Data Access Layer "N-Tier", te recomiendo que eches un vistazo a estos dos cursos (idealmente antes de DDD Fundamentals):

- [Creating N-Tier Applications in C#, Part 1](https://www.pluralsight.com/courses/n-tier-apps-part1)
- [Creating N-Tier Applications in C#, Part 2](https://www.pluralsight.com/courses/n-tier-csharp-part2)

Steve Smith también mantiene la aplicación de referencia de Microsoft, eShopOnWeb, y su libro electrónico gratuito asociado. Consúltalo aquí:

- [eShopOnWeb on GitHub](https://github.com/dotnet-architecture/eShopOnWeb)
- [Architecting Modern Web Applications with ASP.NET Core and Microsoft Azure](https://aka.ms/webappebook) (eBook)

## Disclaimer

Por favor, entiende que este proyecto no es un proyecto cerrrado.
Actualmente el proyecto aún está en desarrollo, y debido a que me encuentro en constante mejora y actualización tanto de éste como de todos mis proyectos personales, desde la manera de estructurar la solución hasta la estructura y capas aplicadas; todo es susceptible de cambiar en un futuro.
Por favor, si tienes alguna sugerencia, cambio o implementación; estaría encantado de escucharte!

