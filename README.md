# [Asp.Net Core 5.0 & Vue JS From Zero to Hero 68 Hours Content](https://www.udemy.com/course/aspnet-core-50-vue-js-from-zero-to-hero-68-hours-content/)

Course Material

## Criando a solução

No Visual Studio, gerar uma solução `ASP .Net Core MVC`:

![ASP.Net Core MVC](img/ASPNetCore_MVC_ProjectCreation.jpg)

Via linha de comando `dotnet`, gerar uma solução `ASP .Net Core MVC`:

```shell
dotnet new mvc -n <name_to_the_project>
cd <name_of_the_project>
dotnet new sln -n <name_to_the_solution>
dotnet sln <name_of_the_solution> add <name_of_the_project>
dotnet new gitignore
```

## Simple Dinamic content on the pages

### ViewData simple example

No arquivo controller:

```csharp
ViewData["message1"] = "ViewData message";
```

No arquivo view:

```html
<h3>@ViewData["message1"]</h3>
```

### ViewBag simple example

No arquivo controller:

```csharp
ViewBag.message2 = "ViewBag message";
```

No arquivo view:

```html
<h3>@ViewBag.message2</h3>
```

### TempData simple example

No arquivo controller:

```csharp
TempData["message3"] = "TempData message";
```

No arquivo view:

```html
<h3>@TempData["message3"]</h3>
```

