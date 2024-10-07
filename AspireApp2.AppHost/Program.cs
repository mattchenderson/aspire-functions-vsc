var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireApp2_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp2_Web>("webfrontend")
   .WithExternalHttpEndpoints()
   .WithReference(apiService);

var blobs = builder.AddAzureStorage("mystorage").RunAsEmulator().AddBlobs("MyAppStorage");

builder.AddAzureFunctionsProject<Projects.FunctionApp1>("functionapp1")
    .WithReference(blobs);

builder.Build().Run();