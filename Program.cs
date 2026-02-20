using Microsoft.Azure.Cosmos;
using static AZ204CosmosDBDemo.Models;

CosmosClient cosmosClient = new CosmosClient(
    connectionString : "AccountEndpoint=;AccountKey=;"
    );

string databaseName = "WizLabsDBMend";
string containerName = "WizLabsContainerMend";

//Get Database
Database database = cosmosClient.GetDatabase(databaseName);
Console.WriteLine($"Database Id: {database.Id}");

//Get Container
Container container = database.GetContainer(containerName);
Console.WriteLine($"Container Id: {container.Id}");

Employee createItemEmployee = new Employee(
    id: Guid.NewGuid().ToString(),
    name: "John Doe",
    role: "Software Engineer",
    departament: "IT"
);

/*
ItemResponse<Employee> createItemResponse = await container.CreateItemAsync<Employee>(
    item: createItemEmployee,
    partitionKey: new PartitionKey("IT"));

Console.WriteLine(createItemResponse.Resource);*/

//REPLACE ITEM

Employee updateItemEmployee = new Employee(
    id: "4832bce0-09d9-4d8a-adb6-17072ae904b8",
    name: "John Doe",
    role: "Backend Java",
    departament: "IT"
);

ItemResponse<Employee> replaceItemResponse =  await container.ReplaceItemAsync<Employee>(
    id: "4832bce0-09d9-4d8a-adb6-17072ae904b8",
    item: updateItemEmployee,
    partitionKey: new PartitionKey("IT")
);

Console.WriteLine(replaceItemResponse.Resource);