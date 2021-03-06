# Adonet-Blog

Descrições gerais do projeto

## Criando a solução

No Visual Studio, gerar uma solução `ASP .Net Core MVC`:

![ASP.Net Core MVC](../img/ASPNetCore_MVC_ProjectCreation.jpg)

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

## Criando um novo arquivo Model

No Visual Studio, clicar com o direito na pasta `Model` e criar uma nova classe.
Ex:

```csharp
namespace Adonet_Blog.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
```

Instanciar a classe recém criada dentro do método `IActionResult` desejado do
arquivo de controller desejado. E passá-la como parâmetro de
`return View(<nome-da-instancia>)`. Ex:

```csharp
public IActionResult Index()
{
    Person person = new Person {
        Name = "Victor",
        Surname = "Almeida"
    };

    return View(person);
}
```

Declarar o model a ser usado no arquivo de view e acessar as propriedades.
Ex:

```html
@model Person ...
<h4>Name: @Model.Name</h4>
<h4>Surname: @Model.Surname</h4>
```

### Acessando propriedades de uma lista

Instanciar uma lista da classe recém criada dentro do método `IActionResult` desejado do
arquivo de controller desejado. E passá-la como parâmetro de
`return View(<nome-da-instancia>)`. Ex:

```csharp
public IActionResult Index()
{
    List<Person> persons = new List<Person>
    {
        new Person()
        {
            Name = "Victor",
            Surname = "Almeida"
        },
        new Person()
        {
            Name = "Caio",
            Surname = "Argolo"
        }
    };

    return View(persons);
}
```

Declarar o model a ser usado no arquivo de view e acessar as propriedades.
Ex:

```html
@model List<Person>
    ... @foreach (var person in Model) {
    <div>
        <h4>Name: @person.Name</h4>
        <h4>Name: @person.Surname</h4>
    </div>
    }</Person
>
```

## [Layout](https://docs.microsoft.com/en-us/aspnet/core/mvc/views/layout?view=aspnetcore-5.0)

Default é definido no arquivo `Views/Shared/_Layout.cshtml`. Para views com
custom layouts usar o decorator `Layout`, como em:

```html
@{ Layout = null; }
```

Exemplo de arquivo view usando um custom layout: Adonet-Blog/Views/Home/AboutUs2.cshtml

## Exibindo dados do Db usando Models

Notar que os arquivos criados no diretório `Models` são automagicamente
importados no arquivo `Adonet-Blog\Views\_ViewImports.cshtml`. De forma a
facilitar sua utilização nos decorators dos arquivos de View.

## Armazenando usuário em um cookie

- [Session and state management in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-5.0)
- [Use cookie authentication without ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/cookie?view=aspnetcore-5.0)
- [Work with SameSite cookies in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/samesite?view=aspnetcore-5.0)