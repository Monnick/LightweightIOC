# LightweightIOC
This is a very leightweight IOC implementation.
## Configuration via appsettings.json
The configuration can be read as json file:   
```json
"DIConfiguration": {
    "Register":
        [{
            "Contract":"Contracts.ITest",
            "Implementation": "Concretes.Implementation"
        },{
            "Contract":"Contracts.IExample2",
            "Implementation": "Concretes.Example"
        }]
  }
```
This configuration can be bind to the configuration class __LightweightIOC.Configuration.DIConfiguration__:    
```C#
var builder = new ConfigurationBuilder()
  .SetBasePath(Directory.GetCurrentDirectory())
  .AddJsonFile("appsettings.json");

var config = builder.Build();
var appConfig = new DIConfiguration();
config.GetSection("DIConfiguration").Bind(appConfig);
LightweightIOC.DIContainer container = new SimpleIOC.DIContainer();
container.ReadConfiguration(appConfig);
```
## Type registration
The core domain builder is implemented in the class __LightweightIOC.DIContainer__.   
1. Registration with type objects
```C#
LightweightIOC.DIContainer container = new LightweightIOC.DIContainer();
container.Register(typeof(Contracts.ITest), typeof(Concretes.Implementation));
```
2. Registration with generic functions
```C#
LightweightIOC.DIContainer container = new LightweightIOC.DIContainer();
container.Register<Contracts.ITest, Concretes.Implementation>();
```
## Resolving an implemtation
The registered interfaces can be resolved via calling the resolve method:
```C#
object implementation = container.Resolve(typeof(Contracts.ITest));
```
If casting to the needed interface is necessary, a generic resolving method is available:
```C#
Contracts.ITest implementation = container.Resolve<Contract.ITest>();
```
## Checking a contract and implementation type reference
### Verify with exception
To verify to ensure all registered types can be resolved, call the method `Verify()`:
```C#
var appConfig = new DIConfiguration();
appConfig.Verify();
```
The method will throw an exception in case of an not found type.   
### Check whether a type is already registered
Call method "IsRegistered":
```C#
var appConfig = new DIConfiguration();
appConfig.IsRegistered(typeof(IMyLocalInterface));
```
## Constructor injection
During creation of an implementation, all known interfaces will be filled with concrete implementations.
```C#
interface ITest { }

interface IExample { }

class Test : ITest { }

class Example : IExample
{
  public Example(ITest test) { }
}
```
On resolving IExample the constructor of its implementation (Example) will be supplied with the implementation (Test) of the interface ITest.
