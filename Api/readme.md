### Command To start hangfireDb
docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_DB=HangfireDb -d -p 5200:5432 postgres

### Command to start emailDb
docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -e POSTGRES_DB=EmailDb -d -p 5432:5432 postgres