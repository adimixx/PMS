# PHOTOG
Photography Management System, A developing system to fullfil the requirement of BITU3923 WORKSHOP II

## Database Connection

SQL Script for Database and Table queries are included inside the project file

## Logged In User Credentials
Developers can access logged in users information, through custom class that have been made.

`Identity()` method returns User object (similar to the ones inside data entity / database) 

```csharp
UserAuthentication.Identity()
```

## Studio Link Verification
Routing has been configured to allow permalinks for studio profiles.

`RouteConfig.cs`
```csharp
routes.MapRoute(
            name: "Studio Profile Page",
            url: "{permalink}/{action}/{id}",
            defaults: new { controller = "Studio", action = "Index", id = UrlParameter.Optional }
);
```

To allow only valid links, Add these custom DataValidation to desired controller
```csharp
[StudioPermalinkValidate]
public ActionResult TestPage()
```
To only allow link to be accessed with roles, use `RoleID`
```csharp
//Only Studio Admin can access
[StudioPermalinkValidate(RoleID = 1)]
public ActionResult TestPage()
```

```csharp
//Studio Admin and Studio Staff can access
[StudioPermalinkValidate(RoleID = 2)]
public ActionResult TestPage()
```


`[StudioAuthorizationRole(RoleID = 1)]` Authorizes access for pages with required authority. 1 for admin only, 2 for admin and staff

## Routing
To allow detection of permalinks, unfortunately every new controller must be registered for their routing manually.

Example below is routing for `AccountController.cs`

`RouteConfig.cs`
```csharp
routes.MapRoute(
    name: "Account",
    url: "Account/{action}/{id}",
    defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
);
```

## Front End
This project has been contains the following Library : 

- Bootstrap v4.5.3
- JQuery v3.5.1
- Vue.js 3.0.2
- FilePond (CDN)


## Developers
[Adi Iman](https://github.com/adimixx)
[Raziq Danish](https://github.com/ahmdraziq)
[Heng Kai](https://github.com/HengKai5191)
[Afiq Iskandar]()