# Taxually technical test - Dávid Bollobás

Repository copied from Github: https://github.com/Taxually/developer-test
Tasks are described in README.md, outside of the project

## General dev notes

- Running project from Visual Studio doesn't open browser automatically, need to open it manually on https://localhost:7132, Swagger is under https://localhost:7132/swagger/index.html
- Removed not secure http endpoint
- Created two environments: Development and Production; configuration in appsettings
- Added AutoMapper to transform between models
- Exchanged "Task.Wait()"-s with async "Task()-s"
- ServiceResults with errors doesn't have Result object 
- The solution is built as a monolith, but it is loosely coupled
- For server error we return Http 500, this sould be more precise (eg.: 403, 400 etc.)
- Taxually.TechnicalTest.Test is a mixture, should be sorted out for unit/integration/projects
- Used Moq as mocking service
- ServiceCollectionExtensions.RegisterVatServices is called to register VatServices project dependencies

## Assumptions

- TaxuallyHttpClient and TaxuallyQueueClient classes are basic implementations, there is no need to put them on lower level
- Errors are handled on API side, but can be moved to lower levels

## Questions to tech team

- What HTTP statuses do we communicate with?
- Should we support not-null policy?

## Questions to product manager

- Should VatRegistration endpoint return a response? VatRegistrationResponse is empty right now
- What error messages should we send back to users?
- What informations can be logged/which of those are sensitive?

## Future ideas

- Add CI/CD
- Integration testing
- More unit tests
- Add correlation id to request processing
- Introduce linter (eg.: StyleCop)
- Add static code analysis
- Extensive logging

## Test feedbacks

- The project file has a wrongly kept README.md file link, it was moved outside of the folder. removed the link