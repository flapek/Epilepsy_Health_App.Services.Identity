# Epilepsy_Health_App.Services.Identity

## What is Epilepsy_Health_App.Services.Identity?

Epilepsy_Health_App.Services.Identity is the microservice being part of [Epilepsy_Health_App](https://github.com/flapek/Epilepsy_Health_App) solution.

Branch             |Build status                                                  
|-------------------|-----------------------------------------------------
|master             |[![Build Status](https://travis-ci.org/flapek/Epilepsy_Health_App.Services.Identity.svg?branch=master)](https://travis-ci.org/flapek/Epilepsy_Health_App.Services.Identity)
|develop            |[![Build Status](https://travis-ci.org/flapek/Epilepsy_Health_App.Services.Identity.svg?branch=develop)](https://travis-ci.org/flapek/Epilepsy_Health_App.Services.Identity)

## How to start the application?

Service can be started locally via `dotnet run` command (executed in the `/src/Epilepsy_Health_App.Services.Identity.Api` directory) or by running `./Scripts/start.sh` shell script in the root folder of repository.

By default, the service will be available under http://localhost:5001 and https://localhost:6001.

You can also start the service via Docker, either by building a local Dockerfile: 

`docker build -t epilepsy_health_app.services.identity .` 

## What HTTP requests can be sent to the microservice API?

You can find the list of all HTTP requests in [Epilepsy_Health_App.Services.Identity.rest](https://github.com/flapek/Epilepsy_Health_App.Services.Identity/blob/master/Epilepsy_Health_App.Services.Identity.rest) file placed in the root folder of the repository.
This file is compatible with [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) plugin for [Visual Studio Code](https://code.visualstudio.com). 