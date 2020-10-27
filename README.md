![tests](https://github.com/dlumpp/StringThings/workflows/tests/badge.svg)

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
Because it's so annoying to type `StringComparison.OrdinalIgnoreCase`.

```cs
using StringThings.Extensions;
// all return true
"ABC".EqualsIgnoreCase("abc");
"ABC".StartsWithIgnoreCase("abc");
"ABC".EndsWithIgnoreCase("abc");
"ABC".ContainsIgnoreCase("abc");
```


## Take First/Last Characters Extensions
No more length errors when using substring to get the leading or trailing characters from a string. Let this extension do the work for you of verifying that your substring doesn't exceed the length of the string you are evaluating.

Prevents this error:
`Index and length must refer to a location within the string.`

```cs
using StringThings.Extensions;
// all return true
"principal".TakeLast(3) *italic*returns "pal"*italic*
"ABC-123".TakeFirst(3) *italic*returns "ABC"*italic*
"tiny".TakeLast(5) *italic*returns "tiny" (with no error!)*italic*
"This is a sentence".TakeFirst(8) *italic*returns "This is "*italic*
```


## Other Useful Extensions
Coming soon
