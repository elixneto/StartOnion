# StartOnion
An Onion Architecture with DDD, CQRS, Notification Pattern & more...

## Install
### Layers
```
install-package StartOnion.Api
install-package StartOnion.Application
install-package StartOnion.Domain
```
### Repositories
```
install-package StartOnion.Repository.RavenDB
install-package StartOnion.Repository.MongoDB
install-package StartOnion.Repository.LiteDB
```
### Dependecy Injection
```
install-package StartOnion.DependencyInjection
```

## Using
```csharp
services.AddMvc(mvc => {
    mvc.Filters.Add<NotificationFilter>(); // <--- StartOnion Notification
    mvc.Filters.Add<UoWMongoDBAsyncFilter>(); // <--- StartOnion MongoDB UoW
    mvc.Filters.Add<UoWRavenDBAsyncFilter>(); // <--- StartOnion RavenDB UoW
    mvc.Filters.Add<UoWLiteDBFilter>(); // <--- StartOnion LiteDB UoW
});

services.AddStartOnionApplication(...);
services.AddStartOnionCrossCutting(...);
services.AddStartOnionRepositoryMongoDB(...);
services.AddStartOnionRepositoryRavenDB(...);
services.AddStartOnionRepositoryLiteDB(...);
```
