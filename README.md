# Eshop
This repo for implement e-commerce project using microservices and  Redis, RabbitMQ Event Driven Communication and alot of beaty tools 😁 
## We have implemented below features
Catalog microservice which includes :
* ASP.NET Core Web API application
* REST API principles, CRUD operations
* Sql Server database connection 
* Swagger Open API implementation
* integration testing for api

Discount microservice which includes:
* ASP.NET Core Web API application
* ASP.NET Grpc Server application
* Build a Highly Performant inter-service gRPC Communication with Basket Microservice
* REST API principles, CRUD operations
* Sql Server database connection 
* Swagger Open API implementation

Basket microservice which includes:
* ASP.NET Web API application
* REST API principles, CRUD operations
* Redis database connection 
* Consume Discount Grpc Service for inter-service sync communication to calculate product final price

API Gateway Ocelot microservice which includes:
* Implement API Gateways with Ocelot
* Sample microservices to reroute through the API Gateways
* Caching

Microservices Communication
* Sync inter-service gRPC Communication
* Async Microservices Communication with RabbitMQ Message-Broker Service
* Using RabbitMQ Publish/Subscribe Topic Exchange Model
* Using MassTransit for abstraction over RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices
* Create RabbitMQ EventBus.Messages library and add references Microservices

Ordering Microservice
*  CQRS, and Clean Architecture with using Best Practices
* Developing CQRS with using MediatR, FluentValidation and AutoMapper packages
* Consuming RabbitMQ BasketCheckout event queue with using MassTransit-RabbitMQ Configuration
* SqlServer database connection and containerization
* Using Entity Framework Core ORM and auto migrate to SqlServer when application startup

WebUI ShoppingApp Microservice
* ASP.NET Core Web Application with Bootstrap 4 and Razor template
* Call Ocelot APIs with HttpClientFactory
* Implement Retry and Circuit Breaker patterns with exponential backoff with IHttpClientFactory and Polly policies
