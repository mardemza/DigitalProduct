# **DigitalProduct**
## Introducción

- Motivo del proyecto: Proyecto para prueba de conocimientos
- Realizado por: Moises Rivas

## Descripción y requisitos
- Proyecto realizado en 4 capas
- Debe tener instalado NET 6

## Implementaciones
- NET 6
- Pattern Repository
- Pattern Mediator
- Entity Framework Core con SQLLite
- LazyCache
- Logger
- Inyección de Dependencia
- API RESTFul

## Proyectos de la solución
1) Proyecto Core\
Es donde se encuentran todos los modelos.

2) Proyecto Entity Framework\
Es donde se hace la relación de los modelos creados en Core y que se relacionan con el contexto del ORM.\
Tambien este proyecto contiene todas las migraciones que se han realizado para aplicar en nuevas DBs.

3) Proyecto Application\
Es donde se encuentra la logica de negocio repartida en servicios que se consumen por inyección de dependencia.

4) Proyecto Api\
Es el proyecto que contiene las APIs que llaman a los servicios para realizar las acciones necesarias.

5) Proyecto Tests\
En este proyecto se encuentran dos test simples de los metodos de los controladores

## Como correr el proyecto

1) Abrir un cmd
2) Ir a la carpeta "**DigitalProduct.Api**"
3) Correr el comando "**dotnet run**"

## Guia de funcionalidad
- En el proyecto API se encuentran dos controladores, el primero se llama ProductController queo es una simple API RESTFul que es para agregar, actualizar, observar y eliminar Productos que estan en la base de datos SQLLite.
- En el segundo controlador ShoopingController esta el ejemplo del uso de Pattern Mediator en el metodo AddToBasquet y tambien se encuentra el GeById que devuelve lo solicitado del Dto Maestro / Detalle que a su vez el Maestro es traido por una llamada GET a un endpoint que retorna un elemento JSON y mapeado en una clase, tambien existe el uso de cache que es para el uso de este objecto.
- En el proyecto API se encuentra una carpeta App_Data donde se encuentra la base de datos SQLLite y tambien se encontrara el archivo de logs que registra todas las llamadas y tiempos de respuesta de los diferentes endpoints.

