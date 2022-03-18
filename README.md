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

## Como correr el proyecto

1) Abrir un cmd
2) Ir a la carpeta "**DigitalProduct.Api**"
3) Correr el comando "**dotnet run**"
