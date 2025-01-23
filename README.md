# Webhooks Example
This solution implements an example of webhooks in an ASP.NET Core 9 project.

## Webhooks
The **Webhooks** project receives weather data via an endpoint. It utilizes basic authorization and an SQLite database to store the data.

## Weather Service
The **Weather** Service project is an ASP.NET Core application representing a weather station that sends data to the Webhooks project at regular intervals. The .NET Core library Caravel is used for scheduling these tasks.
