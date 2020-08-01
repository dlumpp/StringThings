# StringThings
Handy string extensions and utilities for .NET

This is a collection of string things I find myself writing in every project I work on. I want to get it all down in one place so I don't keep rewriting the same stuff. Maybe it can help someone else if I make it public.

## TypedString
Beat primitive obsession by making specific types of strings. Unique types allow you to do things like more easily inject different strings. TypedString implicitly casts to string so it can still be used with code you don't control that requires strings.

```cs
// type to hold a string for your database connection string
public class DbConnectionString : TypedString {
  public DbConnectionString(string value) : base(value) { }
}

// register instance with dependency injection
services.AddSingleton(new DbConnectionString("...from config..."));

// ask for the registered DbConnectionString in your app
public class HomeController(DbConnectionString connStr) {
  public ActionResult Index() {
    var conn = new SqlConnection(connStr);   
  }
}
```

## Case-insensitive Comparison Extensions
Coming soon
