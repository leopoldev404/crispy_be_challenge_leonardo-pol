# Todo Application

## Intro

This repository contains a sample project of a full-stack Todo Application:

- **.github:** contains CI-CD scripts for Github Actions
- **docker:** contains docker-compose and docker files to start required containers
- **frontend:** contains ASP.NET Core 8 Application code
- **backend:** contains ASP.NET Core 8 API Service code

## Dev Environment 👨‍💻

- WSL-2
- Ubuntu 22.04
- Docker
- Visual Studio Code
- Visual Studio Code Extensions (Docker, C#, IntelliCode)

## Run Application 🚀

### **System Requirements:**

- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)

### Startup

1. Clone repository

   > `git clone https://github.com/leopoldev404/crispy_be_challenge_leonardo-pol.git`

2. Go into project folder

   > `cd crispy_be_challenge_leonardo-pol`

3. Set Required Environment Variables (on linux example)

   > export POSTGRES_USER=dev
   >
   > export POSTGRES_PASSWORD=password
   >
   > export APIKEY=key

4. Run Containers

   > `docker-compose -f docker/docker-compose.yml up --build -d`

5. Open your browser on `localhost:4000` and Enjoy!

### Cleanup Environment

1. Go into project folder

   > cd crispy_be_challenge_leonardo-pol

2. Shutdown Containers
   > docker-compose -f docker/docker-compose.yml down

## Features 💥

- [.NET 8]()
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles applied
- Developed following [Best Practices](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-7.0)
- [TDD: Test Driven Development]()
- [Authorization](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-8.0)
- [Serilog](https://github.com/serilog/serilog)
- [Repository Pattern](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-8.0)
- [FluentValidation](https://fluentassertions.com/)
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Mediator Pattern](https://en.wikipedia.org/wiki/Mediator_pattern) using [MediatR package](https://github.com/jbogard/MediatR)
- [Pipeline Behaviors]() for Logging and Validation
- Unit Testing written with [xUnit](https://xunit.net/), [Moq](https://github.com/devlooped/moq) and [FluentAssertions](https://fluentassertions.com/)
- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)
- [PostgreSQL](https://www.mongodb.com/it-it?utm_source=google&utm_campaign=search_gs_pl_evergreen_atlas_core_prosp-brand_gic-null_emea-it_ps-all_desktop_it_lead&utm_term=mongodb&utm_medium=cpc_paid_search&utm_ad=e&utm_ad_campaign_id=20378068754&adgroup=154980289881&cq_cmp=20378068754&gad=1&gclid=EAIaIQobChMI183GxdHXgQMV8oVoCR0pCAM3EAAYASAAEgLRPPD_BwE) as Database
- [Dapper](https://www.mongodb.com/docs/drivers/) for database connection and operations
