# Todo App

## Intro 📄

### Description

This repository contains a simple Todo Full-Stack Application entirely developed using **.NET 8** and its latest features.

### Project structure

- **.github:** contains CI-CD scripts for Github Actions
- **docker:** contains docker-compose and docker files to start containers
- **frontend:** contains ASP.NET Core Razor App code
- **backend:** contains ASP.NET Core 8 API Service code

## Get started 👨‍💻

### Requirements

- [Git](https://git-scm.com/)
- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)

### Run with **Docker Compose**

```sh
# clone repository
$ git clone https://github.com/leopoldev404/crispy_be_challenge_leonardo-pol.git

$ cd crispy_be_challenge_leonardo-pol

# export required environment variables (use "set" keyword on windows)
$ export POSTGRES_USER=dev
$ export POSTGRES_PASSWORD=password
$ export API_KEY=key

# start containers
$ docker-compose -f docker/docker-compose.yml up --build -d
```

**Open your browser on [http://localhost:4000](http://localhost:4000) and Enjoy!**

### Cleanup Environment

```sh
$ cd crispy_be_challenge_leonardo-pol
$ docker-compose -f docker/docker-compose.yml down
```

## Features 💥

- [.NET 8]()
- [Minimal Apis](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-8.0)
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- Developed using [Best Practices](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-8.0)
- [TDD: Test Driven Development](https://learn.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2022)
- [Api Key Authorization](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-8.0)
- [Serilog](https://github.com/serilog/serilog) for logging functionalities
- [Repository Pattern](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
- [FluentValidation](https://www.nuget.org/packages/FluentValidation)
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Mediator Pattern](https://en.wikipedia.org/wiki/Mediator_pattern) using [MediatR package](https://github.com/jbogard/MediatR)
- [Unit Testing]() written with [xUnit](https://xunit.net/), [Moq](https://github.com/devlooped/moq) and [FluentAssertions](https://fluentassertions.com/)
- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [PostgreSQL](https://www.postgresql.org/) as Database
- [Dapper](https://www.nuget.org/packages/Dapper) for database connection and operations
