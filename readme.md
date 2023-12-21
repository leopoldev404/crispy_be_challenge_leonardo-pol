# Todo Application

## **Introduction** ⚙️

This repository contains a sample of a full-stack Todo Application:

- **.github:** contains CI-CD scripts for Github Actions
- **scripts:** contains scripts to startup/cleanup the dev environment
- **docker:** contains docker-compose and docker files to start required containers (postgresql, frontend app, backend service)
- **frontend:** contains frontend code (built with Blazor)
- **backend:** contains the backend service (built with .NET 8)

## **Dev Environment** 👨‍💻

- WSL-2
- Ubuntu 22.04
- Docker
- Visual Studio Code
- Visual Studio Code Extensions (Docker, C#, IntelliCode)

## **Run Application** 🚀

### **System Requirements:**

- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)
- Make sure you can run `.sh` scripts

### **Startup:**

1. `git clone https://github.com/leopoldev404/crispy_be_challenge_leonardo-pol.git`
2. `cd crispy_be_challenge_leonardo-pol`
3. `bash ./scripts/setup.sh` (pull required docker images, build applications, create docker containers and volumes)
4. Open your browser on `localhost:4000`

### Cleanup Environment

`bash ./scripts/cleanup.sh` (remove docker containers and volumes)

## **Features** 💥

- Project structure following [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles
- Developed following [Best Practices](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/best-practices?view=aspnetcore-7.0)
- Based on .NET 8
- TDD: Test Driven Development
- Authorization using static Api Secret Key
- [IDistributedCache](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-7.0) caching implementation
- [Serilog](https://github.com/serilog/serilog)
- [Repository Pattern]()
- [FluentAssertions](https://fluentassertions.com/)
- [CQRS](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Mediator Pattern](https://en.wikipedia.org/wiki/Mediator_pattern) using [MediatR package](https://github.com/jbogard/MediatR)
- [Pipeline Behaviors]() for Logging and Validation
- Unit and Integration Testing with [xUnit](https://xunit.net/), [Testcontainers](https://dotnet.testcontainers.org/) and [FluentAssertions](https://fluentassertions.com/)
- [Docker](https://docs.docker.com/)
- [Docker Compose](https://docs.docker.com/)
- [PostgreSQL](https://www.mongodb.com/it-it?utm_source=google&utm_campaign=search_gs_pl_evergreen_atlas_core_prosp-brand_gic-null_emea-it_ps-all_desktop_it_lead&utm_term=mongodb&utm_medium=cpc_paid_search&utm_ad=e&utm_ad_campaign_id=20378068754&adgroup=154980289881&cq_cmp=20378068754&gad=1&gclid=EAIaIQobChMI183GxdHXgQMV8oVoCR0pCAM3EAAYASAAEgLRPPD_BwE) as Database
- [Dapper](https://www.mongodb.com/docs/drivers/) for database connection and operations

## **Missing** 🤔❓

- CI-CD for Deployment
- More accurate unit tests
- More testing using TestContainers package
- Pagination
