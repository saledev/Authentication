# Authentication

# How to use

```csharp
builder.Services.AddAuthenticationJwtBearer();
```

# Options to configure

```json
{
  "Authentication": {
    "Secret": "verysecretstring",
    "MinutesTokenIsValid": 20
  }
}
```