Our project is structured using ONION architecture
here we have 4 layes
Data, Repo, Service and Api

1)Data layer for
Entity types, Value objects, Enums etc.
in our case we use light version and we dont have any DB tables that is way here we dont have any Entities for that
Data layer don`t have any project referencies 

2)Repo layer
Here we need to implement Repositories for working width DB, using any ORM or ADO.NET
in our case we use light version and we dont have any need to communicate with DB, that is way we dont have any repositories here
for example we can use EF Core, Code first way
Repo layer have Data layer reference

3)Services layer
Here we shold write Businness logic or connect any external API`s
Service layer have Repo layer refeence

4)Api layer
Here we shold have our endpoints (controllers) and socket endpoints
Api layer have Service layer reference

Becose of our project is not wery big we stuructured using ONION architecture

but we also can implement Clean architecture using CQRS, DDD, paterns
in the future if our project will be bigger we can structured microservice architechture and we can use CQRS, DDD, Outbox-Inbox, etc. paterns
we also can use RabbitMQ, or Kafka for microservicies comunication