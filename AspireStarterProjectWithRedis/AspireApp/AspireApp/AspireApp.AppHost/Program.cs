var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WaitFor(cache)
    .WaitFor(apiService)
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
