# Services

Also known as Application layer, does the mediation between the App ([Shoppy](../Shoppy/))
and the Persistence ([DAL](../DAL/)) layers

## Dev Notes

- All Service classes are working with the [Startup](../Shoppy/Startup.cs) class [AddDbContext](AddDbContext) injection, that is using the [appsettings.json](../Shoppy/appsettings.json) ConnectionStrings. No Db info exposed on the [DatabaseContext](../Shoppy/DatabaseContext.cs) OnConfiguring method.