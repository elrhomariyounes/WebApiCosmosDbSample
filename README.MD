### Description :

This a sample project for using Azure CosmosDb and Entity Framework Core.

A CRUD Example is at your disposal.

### Project structure :
* Data folder contains the entities and DbContext
* Infrastructure folder contains the CosmosDb Settings class that is bind to appsettings
* Models folder contains a View Model class for the example
* Services folder contains services class News CRUD example with Entity Framework Core

### Setup :

## Step 1 : Azure Create CosmosDb resource

* Go to your Azure Account
* Create new resource Azure CosmosDb
* Choose CoreSQL as quering language
* Fill the other informations
* Click Review + Create

## Step 2 : Create a Database

* Go to your Azure CosmosDb resource
* In the menu click on Data Explorer
* Click create Database

## Step 3 : Set up project
* On your Azure CosmosDb resource click on Keys section (Right Menu)
* Copy your URI, Primary Key
* Open appsettings.json file
* Paste the uri in the Endpoint section
* Paste the primary key in the Key section
* Write the Database Name that you have created in the step before

## Run the project
