# PostgreSQL Connector Sample App - EntityFramework Core

An ASP.NET Core sample application for the [Steeltoe PostgreSQL Connector](https://steeltoe.io/docs/steeltoe-connectors/#2-0-postgresql).

This sample uses EntityFramework Core to issue commands to the bound database.
There is another sample using [NpgsqlConnection](./PostgreSql).

## Pre-requisites - CloudFoundry

1. Installed Pivotal CloudFoundry
2. Installed PostgreSQL database service (e.g. EDB Postgres or CrunchyPostgreSQL)
3. Installed .NET Core SDK

## Create PostgreSQL Service Instance on CloudFoundry

Create an instance of the PostgreSQL database service (myPostgres) in a org/space:


## Publish App & Push to CloudFoundry

1. Publish app to a local directory, specifying the framework and runtime (select ONE of these commands):
   * dotnet publish -c Release -f netcoreapp3.\*(or 2.\*)
  
1. Push the app using the appropriate manifest (select ONE of these commands):
   * cf push -f manifest.yml -p bin/Release/netcoreapp3.\*(or 2.\*)publish

> Note: The provided manifest(s) will create an app named `postgresefcore-connector` and attempt to bind the app to PostgreSql service `myPostgres`.

## What to expect - CloudFoundry

To see the logs as you startup and use the app: `cf logs postgresefcore-connector`

---

### See the Official [Steeltoe Service Connectors Documentation](https://steeltoe.io/docs/steeltoe-service-connectors) for a more in-depth walkthrough of the samples and more detailed information