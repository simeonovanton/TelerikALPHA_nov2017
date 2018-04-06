# ASP.NET Core MVC - Blog system

## Project Description

Create a **ASP.NET Core MVC application** that is a simple blog system where users can post their own blog posts.

The application:
* must have **public part** (accessible without authentication)
* must have **private part** (available for registered users)
* should have **administrative part** (available for administrators only)

### Public Part

The **public part** of your projects must be **visible without authentication**. This includes:

- Must have - Landing page with most recent blog posts
- Must have - Login page
- Must have - Register page

### Private Part (Users only)

**Registered users** must have private part in the web application accessible after **successful login**. This includes:

- Must be able to - Post blog posts. Each blog post must contain title, content, publish date and author and should contain category, tags, etc..
- Should be able to - Post comments on each blog post. Each comment must contain content, author and publish date.

### Administration Part

**System administrators** could have administrative page for managing posts, comments and users.

## General Requirements

Your Web application should use the following technologies, frameworks and development techniques:
* Use **ASP.NET Core MVC** and **Visual Studio 2017**
* You should use **Razor** template engine for generating the UI
	* Use at least **1 section** and at least **1 partial views**
* Use **MS SQL Server** as database back-end
	* Use **Entity Framework Core** to access your database
	* Using **service layer** is a must
* Use at least **1 areas** in your project (e.g. for administration)
* Use the standard **ASP.NET Identity System** for managing users and roles
* Use the default dependency container (or Autofac/Ninject/Unity) and **Automapper**
* Write at least **10 unit tests** for your logic, controllers, actions, helpers, routes, etc.
* Apply **error handling** and **data validation** to avoid crashes when invalid data is entered (both client-side and server-side)

### Optional Advanced Requirements

* Prevent yourself from **security** holes (XSS, XSRF, Parameter Tampering, etc.)
	* Handle correctly the **special HTML characters** and tags like `<script>`, `<br />`, etc.
* Use **AJAX form and/or SignalR** communication in some parts of your application
* Use **Caching** of data where it makes sense (e.g. starting page)
* Use **Roles** using Identity to create admins 

## Guide

1. Create a new ***ASP.NET Core MVC project**, targeting ASP.NET Core 2.0 with local users.
1. Extract ApplicationDbContext into seperate **Class Library (.NET Core)** that references NuGet package Microsoft.AspNetCore.All
1. Extract ApplicationUser into seperate **Class Library (.NET Core)** that references NuGet package Microsoft.AspNetCore.All
1. Yes, by referencing Microsoft.AspNetCore.All, we are **coupling the data layer** with ASP.NET which is a presentation logic framework. We need that coupling because of the User's Identity dependency.
1. Fix the namespaces of those extracted entities. You also have to go though **all account related views** that inject UserManager and fix the references to point to those newly created libraries.
1. Extract services into a seperate **Class Library (.NET Core)**
1. Attach AutoMapper by referencing NuGet packages **AutoMapper** inside the client, service and DTO assemblies then attach it.

```cs
public void ConfigureServices(IServiceCollection services) {
    services.AddMvc(); // Already included. Add your code below this.
    services.AddSingleton<IMapper>(AutoMapperConfig.Initialize()); 
```
8. Create a new mapping config somewhere inside the web client, preferably in an Infrastructure folder.

```cs
public class AutoMapperConfig
{
	public static IMapper Initialize()
	{
	    var types = AppDomain.CurrentDomain
		.GetAssemblies()
		.Where(x => !x.IsDynamic)
		.SelectMany(x => x.GetReferencedAssemblies())
		.Select(x => Assembly.Load(x))
		.SelectMany(x => x.GetTypes());

	    Mapper.Initialize(cfg => Load(types, cfg));

	    return Mapper.Instance;
	}	
}
```

9. Optionally create an automapper provider to avoid coupling your code with IMapper.
10. I personally like to start with data models. Create data models for Post, Comment and etc.
11. Create a PostsService and PostDto and call it inside HomeController. After mapping it to a ViewModel, display it in the view.
12. Create a seperate controller for post publishing, which is decorated with [Authorize] in order to allow only registered users to access it.