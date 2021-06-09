
Time taken: 3.5 to 4 hours

Things I would do if I had more time/resources:

- Add logging (ILogger could be injected just like the services are)
- More testing, especially unit tests (I just used postman/swagger ui to test service during development)
- Move some hard-coded values to json settings file, such as date formats etc
- Use KeyVault or similar service to store secrets such as connection strings, service URLs etc
- Select required rows from product table for better performance rather than the entire table (using test method to select all is a bit of a cheat but it's quicker to develop and just about acceptable for a small amount of data)
- Better exception handling (centralised?)

Additional tasks to make suitable for production:

- Testing, testing, testing! Unit and integration tests.
- CI/CD
- Isolate credentials better so moving to test/integration/prod environment is less risky/more reliable
- Wrap using APIM for better (and easier managed) security
