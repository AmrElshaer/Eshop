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

WebUI ShoppingApp Microservice
* ASP.NET Core Web Application with Bootstrap 4 and Razor template
* Call Ocelot APIs with HttpClientFactory
* Implement Retry and Circuit Breaker patterns with exponential backoff with IHttpClientFactory and Polly policies
