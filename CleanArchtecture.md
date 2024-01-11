Clean architecture has four layers: domain, application, infrastructure, and presentation. Each layer has its own responsibilities and rules.

- The core of the architecture is the domain layer where important business rules and entities are defined
- The application layer orchestrates the domain layer and handles business logic
- The infrastructure and presentation layers are on the outer edges of the architecture
- The domain layer cannot reference any other layer, but the outer layers can reference the domain layer

## Domain

- The entity class contains only one property, which is the id of the entity.
- The abstractions folder has interfaces for the webinar repository and unit of work.

## Application

- The application layer acts as an orchestrator for the system, defining the most important use cases.
- The application layer uses the CQRS pattern to separate command and query flows.
  - In the command side, there is a 'create webinar' command which contains the necessary data to create a new webinar.
  - The command handler handles this command and creates a new webinar using the webinar repository defined in the domain layer.
  - In the query side, there is a 'get webinar by id' query which returns a response based on the webinar id.
  - The Mediator library allows the implementation of a pipeline behavior for wrapping command/query handlers and executing accompanying logic. It is used for validating commands and throwing validation exceptions if necessary

## Infrastructure

The infrastructure layer handles external systems like email notification, message queues, and storage services.
The persistence layer handles database access.
The infrastructure layer handles external systems and hides implementation details.
The infrastructure layer includes the definition of the database context and a simple repository implementation for inserting webinars

## Presentation

The presentation layer provides an entry point for users to interact with the system.
The presentation layer contains controllers that handle incoming HTTP requests.

Moving controllers into the presentation class library gives complete control over the architecture.

The web application can reference all projects in the solution.
The controllers inside the web application have access to everything defined inside the application.
Injecting the application db context in the webinars controller breaks the CQRS implementation.
Moving controllers into the presentation class library allows control over referencing other projects.
One piece of configuration is needed for controllers to function outside of the web application.

