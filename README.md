To run, you need to fill in the values marked as "--- override in user secrets ---" in the appsettings.json file or add them to the user secrets.

![image](https://user-images.githubusercontent.com/107459104/219943244-9679b0a8-6590-4ac6-9ef6-0ddf18ff97ee.png)

The access token is obtained in the API


Example of filling user secrets:

```json
{
  "ConnectionStrings": {
    "Sql": "Data Source=localhost;Database=SmartTestTask;User Id=sa;Password=Password; Integrated Security = True; Connect Timeout = 30; MultipleActiveResultSets = true;Trusted_Connection = False;TrustServerCertificate = True;"
  },
  "Auth": {
    "SecretKey": "M6jFa47MTkvugUr47sIdMJDiQK4H4g0W"
  }
}
```

Liquid access token by the specified secret key (M6jFa47MTkvugUr47sIdMJDiQK4H4g0W) in the user's secrets -

```json
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIwMTYxYWQ3Yi05NTkwLTRlYjgtODIxYy1jMGJmMmZkMWVhMjAiLCJ1bmlxdWVfbmFtZSI6IlRlc3QgVXNlciIsIm5iZiI6MTY3NjgwMzI2MiwiZXhwIjoxNzA4MzM5MjYyLCJpc3MiOiJTbWFydCIsImF1ZCI6Ik9wZW4ifQ.R70pTAMLrxxmH_w-feoyDRiwczLZUh9mzofdT6twjak
```
