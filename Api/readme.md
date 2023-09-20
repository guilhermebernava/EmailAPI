### Command To start hangfireDb
docker run --name hangfireDb -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_DB=HangfireDb -d -p 5200:5432 postgres

### Command to start emailDb
docker run --name emailDb -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_DB=EmailDb -d -p 5432:5432 postgres

### Command to create tables
dotnet update database