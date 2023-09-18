# EmailAPI
EmailAPI to make CRUD to send email using GraphQL

### Command to build and start API
```
docker build -t my-api-image -f Dockerfile .
docker run -d -p 8080:80 --name my-api-container my-api-image
```

### Command to run SQL SERVER in docker
```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrongPassword' -e 'MSSQL_PID=Express' --name emailDb -d -p 1433:1433 mcr.microsoft.com/mssql/server:latest
```

