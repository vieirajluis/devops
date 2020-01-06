# MySql Connector Sample App - EntityFramework Core

ASP.NET Core sample app illustrating how to use the EntityFramework Core together with [Steeltoe MySql Connector](https://github.com/SteeltoeOSS/Connectors/tree/master/src/Steeltoe.CloudFoundry.Connector.MySql) for connecting to a MySql service on CloudFoundry. There is also an additional sample which illustrates how to use a `MySqlConnection` to issue commands to the bound database.

## Pre-requisites - CloudFoundry

1. Installed Pivotal CloudFoundry
2. Installed MySql marketplace service
3. Installed .NET Core SDK

## Create MySql Service Instance on CloudFoundry

You must first create an instance of the MySql service (myMySqlService) in a org/space.


## Publish App & Push to CloudFoundry

1. Publish app to a local directory, specifying the framework and runtime (select ONE of these commands):
   * dotnet publish -c Release -f netcoreapp3.0
   
1. Push the app using the appropriate manifest (select ONE of these commands):
   * cf push -f manifest.yml -p bin/Release/netcoreapp3.0/publish
 

> Note: The provided manifest will create an app named `mysqlefcore-connector` and attempt to bind the app to MySql service `myMySqlService`.

## What to expect - CloudFoundry

To see the logs as you startup and use the app: `cf logs mysqlefcore-connector`

---

### See the Official [Steeltoe Service Connectors Documentation](https://steeltoe.io/docs/steeltoe-service-connectors) for a more in-depth walkthrough of the samples and more detailed information