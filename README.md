Project Management SystemFull-Stack Tech Lead Project | Angular 18+ & .NET 8+1. PROJECT OVERVIEWThis project is a robust, real-time Project Management System designed to streamline task tracking, team collaboration, and project lifecycle management. It provides a comprehensive platform for creating projects, assigning tasks, managing user roles, and receiving instant updates, making it an ideal solution for agile development teams and project managers.Tech Stack Overview
Backend:

Framework: .NET 8+ (ASP.NET Core)
Language: C#
ORM: Entity Framework Core
Authentication: JWT (JSON Web Tokens)
Testing: xUnit, Moq
Logging: Serilog
Real-time: SignalR
Database: PostgreSQL


Frontend:

Framework: Angular 18+
Language: TypeScript
Reactive Programming: RxJS
Testing: Jasmine, Karma/Vitest
Styling: SCSS (or a chosen UI library like Angular Material)


Tools & DevOps:

Version Control: Git
Containerization: Docker (for local development and deployment)
CI/CD: GitHub Actions (example provided)


Architecture ApproachThe project adopts a Clean Architecture (Onion Architecture) pattern for the backend, ensuring a clear separation of concerns, high maintainability, and testability. The frontend follows a Modular Architecture with lazy-loaded features, promoting scalability and efficient development.
Backend:

Domain Layer: Contains core business entities, value objects, and interfaces.
Application Layer: Orchestrates business logic, defines use cases, DTOs, commands, and queries.
Infrastructure Layer: Implements interfaces defined in the Application layer, handling data persistence (EF Core), external services, and logging.
API Layer: The presentation layer, exposing RESTful endpoints, handling authentication, and dependency injection.


Frontend:

Core Module: Global services, guards, interceptors.
Shared Module: Reusable UI components, pipes, directives.
Feature Modules: Lazy-loaded modules for specific functionalities (e.g., Projects, Dashboard, Auth).


2. PREREQUISITESBefore you begin, ensure you have the following software installed on your system:Required Software Versions
Backend:

.NET SDK 8.0 or higher
PostgreSQL 13+ (or Docker for PostgreSQL)
IDE: Visual Studio 2022+ or VS Code


Frontend:

Node.js v18.x or v20.x (LTS versions recommended)
npm (comes with Node.js)
Angular CLI 18.x (install globally: npm install -g @angular/cli)
IDE: VS Code recommended


System Requirements
Operating System: Windows, macOS, or Linux
RAM: Minimum 8GB (16GB recommended for smooth development)
Disk Space: At least 5GB free space
3. QUICK START - BACKEND (.NET)Follow these steps to get the .NET API up and running.3.1. Clone the Repositorybash
git clone https://github.com/your-username/ProjectManagementSystem.git
cd ProjectManagementSystem3.2. Navigate to the Backend Directorybash
cd src/Backend/ProjectManagementSystem.API3.3. Restore Dependenciesdotnet restore3.4. Database Setup with EF Core
Ensure PostgreSQL is running:

If using Docker:


        docker run --name pg-project-management -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=password -e POSTGRES_DB=projectdb -p 5432:5432 -d postgres:13*   Otherwise, ensure your local PostgreSQL instance is active.
Update Connection String:

Open appsettings.Development.json (or appsettings.json for production) and update the DefaultConnection string if your PostgreSQL credentials or host differ.


json123456    {
      "ConnectionStrings": {<br/>
        "DefaultConnection": "Host=localhost;Port=5432;Database=projectdb;Username=admin;Password=password"
      },
      // ... other settings
    }    {
      "ConnectionStrings": {<br/>
        "DefaultConnection": "Host=localhost;Port=5432;Database=projectdb;Username=admin;Password=password"
      },
      // ... other settings
    }
Apply Migrations:
    dotnet ef database updateThis will create the database and tables based on the Entity Framework Core migrations.3.5. Running the APIdotnet run --project ProjectManagementSystem.APIThe API will typically run on https://localhost:5001 (HTTPS) and http://localhost:5000 (HTTP). You can access the Swagger UI for API documentation at https://localhost:5001/swagger.3.6. Testing CommandsTo run all backend unit and integration tests:dotnet test4. QUICK START - FRONTEND (Angular)Follow these steps to get the Angular application running.4.1. Navigate to the Frontend Directorycd ../../Frontend/project-management-app4.2. Install Angular CLI (if not already installed)npm install -g @angular/cli4.3. Install Dependenciesnpm install4.4. Running the Development Serverng serve --openThis command will compile the Angular application and open it in your default browser at http://localhost:4200. The application will automatically reload if you change any of the source files.4.5. Testing CommandsTo run all frontend unit tests:ng testTo run end-to-end (E2E) tests (requires a separate setup, e.g., Cypress or Playwright):ng e2e(Note: E2E setup might require additional configuration based on the chosen framework.)5. PROJECT STRUCTURE5.1. Backend Folder Structure (src/Backend)textsrc/Backend/
├── ProjectManagementSystem.Domain/
│   ├── Entities/             # Core business entities (e.g., Project, Task, User)
│   ├── ValueObjects/         # Immutable objects representing descriptive aspects (e.g., Email, PasswordHash)
│   ├── Enums/                # Domain-specific enumerations
│   ├── Exceptions/           # Custom domain exceptions
│   └── Interfaces/           # Repository interfaces, domain services interfaces
├── ProjectManagementSystem.Application/
│   ├── UseCases/             # Application-specific business logic (commands, queries, handlers)
│   ├── DTOs/                 # Data Transfer Objects for API communication
│   ├── Interfaces/           # Interfaces for infrastructure services (e.g., IEmailService, IDateTimeProvider)
│   ├── Mappers/              # AutoMapper profiles or manual mappers
│   └── Validators/           # FluentValidation rules for DTOs/commands
├── ProjectManagementSystem.Infrastructure/
│   ├── Persistence/          # EF Core DbContext, Migrations, Repositories implementations
│   ├── Services/             # Implementations of external services (e.g., EmailService, JwtService)
│   ├── Identity/             # Identity management (e.g., custom UserStore)
│   └── Logging/              # Serilog configuration and sinks
├── ProjectManagementSystem.API/
│   ├── Controllers/          # RESTful API endpoints
│   ├── Filters/              # Custom action filters (e.g., validation filter)
│   ├── Middleware/           # Custom middleware (e.g., error handling)
│   ├── Hubs/                 # SignalR Hubs for real-time communication
│   ├── Extensions/           # Extension methods for DI, configuration
│   ├── appsettings.json      # Application configuration
│   └── Program.cs            # Application entry point, DI setup
└── tests/
    ├── ProjectManagementSystem.Application.Tests/ # Unit tests for Application layer
    └── ProjectManagementSystem.API.Tests/         # Integration tests for API layersrc/Backend/
├── ProjectManagementSystem.Domain/
│   ├── Entities/             # Core business entities (e.g., Project, Task, User)
│   ├── ValueObjects/         # Immutable objects representing descriptive aspects (e.g., Email, PasswordHash)
│   ├── Enums/                # Domain-specific enumerations
│   ├── Exceptions/           # Custom domain exceptions
│   └── Interfaces/           # Repository interfaces, domain services interfaces
├── ProjectManagementSystem.Application/
│   ├── UseCases/             # Application-specific business logic (commands, queries, handlers)
│   ├── DTOs/                 # Data Transfer Objects for API communication
│   ├── Interfaces/           # Interfaces for infrastructure services (e.g., IEmailService, IDateTimeProvider)
│   ├── Mappers/              # AutoMapper profiles or manual mappers
│   └── Validators/           # FluentValidation rules for DTOs/commands
├── ProjectManagementSystem.Infrastructure/
│   ├── Persistence/          # EF Core DbContext, Migrations, Repositories implementations
│   ├── Services/             # Implementations of external services (e.g., EmailService, JwtService)
│   ├── Identity/             # Identity management (e.g., custom UserStore)
│   └── Logging/              # Serilog configuration and sinks
├── ProjectManagementSystem.API/
│   ├── Controllers/          # RESTful API endpoints
│   ├── Filters/              # Custom action filters (e.g., validation filter)
│   ├── Middleware/           # Custom middleware (e.g., error handling)
│   ├── Hubs/                 # SignalR Hubs for real-time communication
│   ├── Extensions/           # Extension methods for DI, configuration
│   ├── appsettings.json      # Application configuration
│   └── Program.cs            # Application entry point, DI setup
└── tests/
    ├── ProjectManagementSystem.Application.Tests/ # Unit tests for Application layer
    └── ProjectManagementSystem.API.Tests/         # Integration tests for API layer5.2. Frontend Folder Structure (src/Frontend/project-management-app)textsrc/Frontend/project-management-app/
├── src/
│   ├── app/
│   │   ├── core/               # Core services (AuthService, ErrorHandlerService), Guards, Interceptors
│   │   ├── shared/             # Reusable UI components, pipes, directives, models
│   │   ├── features/           # Lazy-loaded feature modules (e.g., projects, dashboard, auth)
│   │   │   ├── auth/           # Login, Register components, services
│   │   │   ├── projects/       # Project list, detail, creation components, services
│   │   │   └── dashboard/      # Dashboard components, widgets
│   │   ├── app.config.ts       # Root application configuration (standalone)
│   │   ├── app.routes.ts       # Main routing configuration
│   │   └── app.component.ts    # Root component
│   ├── assets/                 # Static assets (images, icons)
│   ├── environments/           # Environment-specific configurations (e.g., API URLs)
│   ├── styles/                 # Global styles (SCSS)
│   └── main.ts                 # Application bootstrap
├── e2e/                        # End-to-end tests (e.g., Cypress, Playwright)
├── angular.json                # Angular CLI configuration
├── package.json                # Project dependencies and scripts
└── tsconfig.json               # TypeScript configurationsrc/Frontend/project-management-app/
├── src/
│   ├── app/
│   │   ├── core/               # Core services (AuthService, ErrorHandlerService), Guards, Interceptors
│   │   ├── shared/             # Reusable UI components, pipes, directives, models
│   │   ├── features/           # Lazy-loaded feature modules (e.g., projects, dashboard, auth)
│   │   │   ├── auth/           # Login, Register components, services
│   │   │   ├── projects/       # Project list, detail, creation components, services
│   │   │   └── dashboard/      # Dashboard components, widgets
│   │   ├── app.config.ts       # Root application configuration (standalone)
│   │   ├── app.routes.ts       # Main routing configuration
│   │   └── app.component.ts    # Root component
│   ├── assets/                 # Static assets (images, icons)
│   ├── environments/           # Environment-specific configurations (e.g., API URLs)
│   ├── styles/                 # Global styles (SCSS)
│   └── main.ts                 # Application bootstrap
├── e2e/                        # End-to-end tests (e.g., Cypress, Playwright)
├── angular.json                # Angular CLI configuration
├── package.json                # Project dependencies and scripts
└── tsconfig.json               # TypeScript configuration6. KEY FEATURES IMPLEMENTATION6.1. Clean Architecture LayersThe backend is structured into distinct layers: Domain, Application, Infrastructure, and API. This separation ensures that business rules are independent of frameworks, databases, and UI. Dependencies flow inwards, meaning the API depends on Application, Application depends on Domain, and Infrastructure depends on Application and Domain.6.2. JWT Authentication
Backend: Implemented using Microsoft.AspNetCore.Authentication.JwtBearer. Upon successful login, a JWT is generated with user claims and returned to the client. This token is then used for subsequent authenticated requests.
Frontend: An AuthService handles login/logout and stores the JWT securely (e.g., in localStorage). An JwtInterceptor automatically attaches the token to outgoing HTTP requests.
6.3. Lazy Loading in AngularFeature modules (e.g., ProjectsModule, DashboardModule) are configured for lazy loading in app.routes.ts. This means their code is only loaded when the user navigates to a route associated with that module, significantly improving the initial load time of the application.6.4. Guards and Interceptors
Guards: AuthGuard (e.g., CanActivateFn) protects routes, ensuring only authenticated users can access certain parts of the application. RoleGuard can be extended to restrict access based on user roles.
Interceptors:

JwtInterceptor: Automatically adds the JWT to the Authorization header of HTTP requests.
ErrorInterceptor: Catches HTTP errors, handles them globally (e.g., displaying notifications, redirecting on 401/403 errors), and rethrows them for component-specific handling.


6.5. RxJS Advanced PatternsRxJS is extensively used for asynchronous operations and state management in the frontend.
Operators: map, filter, switchMap, debounceTime, distinctUntilChanged are used for data transformation, filtering, and handling asynchronous streams.
Subjects: BehaviorSubject and ReplaySubject are utilized for managing application state (e.g., user authentication status, global notifications) and sharing data between components.
6.6. Unit Testing (xUnit, Jasmine)
Backend: Unit tests are written using xUnit for the test framework and Moq for mocking dependencies. Tests cover the Domain and Application layers, ensuring business logic and use cases function correctly in isolation.
Frontend: Unit tests are written using Jasmine and run with Karma (or Vitest). Tests cover components, services, pipes, and directives, utilizing Angular's TestBed for effective component testing.
6.7. CI/CD Pipeline SetupA basic CI/CD pipeline is configured using GitHub Actions to automate the build and test process for both frontend and backend.
Workflow: On every push or pull request to main or develop branches, the pipeline triggers, building both projects and running all unit tests.
Example (.github/workflows/ci.yml):
yaml123456789101112131415161718192021222324252627282930313233343536373839404142    name: CI/CD Pipeline

    on:<br/>
      push:<br/>
        branches: [ main, develop ]<br/>
      pull_request:<br/>
        branches: [ main, develop ]

    jobs:<br/>
      build-and-test:<br/>
        runs-on: ubuntu-latest

        steps:<br/>
        - uses: actions/checkout@v3

        - name: Setup .NET<br/>
          uses: actions/setup-dotnet@v3<br/>
          with:<br/>
            dotnet-version: '8.0.x'

        - name: Restore Backend Dependencies<br/>
          run: dotnet restore src/Backend/ProjectManagementSystem.API

        - name: Build Backend<br/>
          run: dotnet build src/Backend/ProjectManagementSystem.API --no-restore

        - name: Test Backend<br/>
          run: dotnet test src/Backend/tests --no-build --verbosity normal

        - name: Setup Node.js<br/>
          uses: actions/setup-node@v3<br/>
          with:<br/>
            node-version: '20.x'

        - name: Install Frontend Dependencies<br/>
          run: npm install --prefix src/Frontend/project-management-app

        - name: Build Frontend<br/>
          run: npm run build --prefix src/Frontend/project-management-app

        - name: Test Frontend<br/>
          run: npm run test:ci --prefix src/Frontend/project-management-app    name: CI/CD Pipeline

    on:<br/>
      push:<br/>
        branches: [ main, develop ]<br/>
      pull_request:<br/>
        branches: [ main, develop ]

    jobs:<br/>
      build-and-test:<br/>
        runs-on: ubuntu-latest

        steps:<br/>
        - uses: actions/checkout@v3

        - name: Setup .NET<br/>
          uses: actions/setup-dotnet@v3<br/>
          with:<br/>
            dotnet-version: '8.0.x'

        - name: Restore Backend Dependencies<br/>
          run: dotnet restore src/Backend/ProjectManagementSystem.API

        - name: Build Backend<br/>
          run: dotnet build src/Backend/ProjectManagementSystem.API --no-restore

        - name: Test Backend<br/>
          run: dotnet test src/Backend/tests --no-build --verbosity normal

        - name: Setup Node.js<br/>
          uses: actions/setup-node@v3<br/>
          with:<br/>
            node-version: '20.x'

        - name: Install Frontend Dependencies<br/>
          run: npm install --prefix src/Frontend/project-management-app

        - name: Build Frontend<br/>
          run: npm run build --prefix src/Frontend/project-management-app

        - name: Test Frontend<br/>
          run: npm run test:ci --prefix src/Frontend/project-management-app6.8. SignalR for Real-time NotificationsSignalR is integrated into the backend to enable real-time communication. This allows for instant updates, such as:
Notifications for new tasks or comments.
Live updates on project status changes.
Chat functionalities within projects (if implemented).
The frontend connects to the SignalR hub and subscribes to specific events to receive these updates.
6.9. Logging with SerilogSerilog is used for structured logging in the backend. It's configured to output logs to the console, files, and can be extended to external logging services (e.g., Seq, ELK Stack). Structured logging makes it easier to query and analyze logs, especially in production environments.6.10. Swagger/OpenAPI DocumentationThe backend API is automatically documented using Swagger/OpenAPI. This provides an interactive UI (/swagger) where developers can explore endpoints, understand request/response models, and even test API calls directly from the browser.7. DEVELOPMENT WORKFLOW7.1. Git Commit ConventionsThis project adheres to the Conventional Commits specification. Commit messages should follow the format: <type>(<scope>): <description>.
Types:

feat: A new feature
fix: A bug fix
docs: Documentation only changes
style: Changes that do not affect the meaning of the code (white-space, formatting, missing semicolons, etc.)
refactor: A code change that neither fixes a bug nor adds a feature
perf: A code change that improves performance
test: Adding missing tests or correcting existing tests
chore: Changes to the build process or auxiliary tools and libraries such as documentation generation


Example: feat(projects): add new project creation form
7.2. Code Review GuidelinesAll code changes must go through a peer code review process. Reviewers should focus on:
Correctness: Does the code solve the problem?
Readability: Is the code easy to understand and maintain?
Performance: Are there any obvious performance bottlenecks?
Security: Are common security vulnerabilities addressed?
Adherence to Standards: Does the code follow established coding guidelines and architectural patterns?
Test Coverage: Are new features/bug fixes adequately tested?
7.3. Testing Requirements
Unit Tests: All new features and bug fixes must include corresponding unit tests. A minimum of 80% code coverage is expected for critical business logic and application services.
Integration Tests: Key API endpoints and data persistence logic should have integration tests.
E2E Tests: Critical user flows should be covered by end-to-end tests.
7.4. Pull Request TemplateA PULL_REQUEST_TEMPLATE.md is provided to guide contributors in creating comprehensive pull requests. It typically includes sections for:
What does this PR do?
Why is it needed?
How to test?
Screenshots/Videos (if applicable)
Related issues/PRs
8. DEPLOYMENT8.1. Docker SetupDockerfiles are provided for both the backend API and the Angular frontend. A docker-compose.yml file is available for local development, allowing you to spin up the entire application stack (API, Frontend, Database) with a single command:docker-compose up --build8.2. Environment Configuration
Backend: Environment-specific settings are managed via appsettings.{Environment}.json files and environment variables. Sensitive information (e.g., database connection strings, JWT secrets) should always be stored in environment variables in production.
Frontend: Angular uses src/environments/environment.ts and src/environments/environment.prod.ts for environment-specific configurations (e.g., API base URL).
8.3. Production ChecklistBefore deploying to production, ensure the following:
Security:

All sensitive data (connection strings, API keys, JWT secrets) are stored securely as environment variables.
HTTPS is enforced for all traffic.
CORS policies are correctly configured for production domains.


Performance:

Backend is built in Release configuration.
Frontend is built with ng build --configuration production.
Database migrations are applied.


Monitoring & Logging:

Logging levels are set appropriately for production.
Monitoring tools (e.g., Prometheus, Grafana, Application Insights) are integrated.


Backup Strategy:

A robust database backup and restore strategy is in place.


9. CONTRIBUTINGWe welcome contributions to this project! Please follow these guidelines to ensure a smooth collaboration.9.1. Code Standards
Backend (C#): Adhere to the Microsoft C# Coding Conventions. Use EditorConfig for consistent formatting.
Frontend (TypeScript/Angular): Follow the Angular Style Guide. ESLint and Prettier are configured to enforce code style automatically.
9.2. Branching StrategyThis project uses a GitHub Flow-like branching strategy:
main: Represents the production-ready code. Only stable, tested code should be merged here.
develop: The main integration branch for ongoing development. All feature branches are merged into develop.
Feature Branches: Create a new branch from develop for each new feature or bug fix (e.g., feature/add-task-comments, fix/login-issue).
9.3. Pull Request Process
Fork the repository and clone it locally.
Create a new feature branch from develop.
Make your changes, ensuring all tests pass and code standards are met.
Commit your changes using Conventional Commits.
Push your branch to your forked repository.
Open a Pull Request from your feature branch to the develop branch of the main repository.
Fill out the provided PULL_REQUEST_TEMPLATE.md thoroughly.
Address any feedback from code reviewers.
Once approved, your changes will be merged.
10. TROUBLESHOOTINGCommon Issues and Solutions
Backend: dotnet ef database update fails

Solution: Ensure your PostgreSQL server is running and accessible. Double-check the connection string in appsettings.Development.json for correctness (host, port, username, password, database name).


Backend: API not starting (port conflict)

Solution: Check if another application is using ports 5000/5001. You can change the ports in launchSettings.json or kill the conflicting process.


Backend: JWT authentication issues

Solution: Verify that the JWT secret key is consistent between token generation and validation. Check token expiration and ensure it's being sent correctly in the Authorization header.


Frontend: npm install fails

Solution: Clear your npm cache (npm cache clean --force). Ensure you have a compatible Node.js version installed (v18.x or v20.x). Delete node_modules and package-lock.json and try npm install again.


Frontend: ng serve fails

Solution: Check for port conflicts (default is 4200). Ensure Angular CLI is installed globally and up-to-date. Review the console for specific error messages.


Frontend: API calls failing (CORS error)

Solution: Ensure the backend's CORS policy is configured to allow requests from your Angular application's origin (http://localhost:4200 during development).


Docker: docker-compose up fails

Solution: Ensure Docker Desktop (or Docker Engine) is running. Check the logs for specific container errors. Ensure no other processes are using the exposed ports.


If you encounter an issue not listed here, please check the project's issue tracker or open a new issue with a detailed description of the problem.