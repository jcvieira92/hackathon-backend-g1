# hackathon_backdotnet_g1
An example app with Docker Compose

## Run with docker-compose

To start the docker-compose environment:

```
docker-compose build
docker-compose up
```

## Clear volume data

To clear data from postgres volume:

```
docker-compose down -v
```

## Support links

* Docker compose with ASP.Net + EF + PostgreSQL: https://medium.com/front-end-weekly/net-core-web-api-with-docker-compose-postgresql-and-ef-core-21f47351224f
* EF Migrations: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-3.1
* Install PostgreSQL in Ubuntu 18.04: https://linuxize.com/post/how-to-install-postgresql-on-ubuntu-18-04/