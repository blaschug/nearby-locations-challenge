# **Nearby Locations Challenge**

### ASP.NET Core API, which receives coordinates and returns information about nearby locations, can also be filtered by categories.

### Also, it shows information about successful requests made to the API on a console app via SignalR messages.

<br>

# **Local deploy guide**

### **Prerequisites:**
- .NET SKD 7.0 ([Download](https://dotnet.microsoft.com/en-us/download))
- Docker ([Download](https://www.docker.com/))

<br>


# **Instructions:**


## 1)   Clone repository
    
```
git clone https://github.com/blaschug/nearby-locations-challenge.git
```
<br>

## 2)  Go to root folder

```
 cd .\nearby-locations-challenge\
```
<br>

##  3) Run docker compose to deploy database and WebApi

```
docker compose up
```

<br>

##  4) Run Console App


### You ca run it just by using any IDE of your preference or from terminal. In this example I will do it with the terminal
<br>

 - Go to console app directory 
```
cd ./LocationsConsoleApp/src
```


 - Build and Run project 
```
dotnet restore && dotnet build && dotnet run
```
<br>

##  5) Try it!

You can user Curl or just your web browser.

Current endpoints are `GET /locations` to get all records from database  and `POST /locations/nearby`. 
Also, `/swagger` for more detailed documentation.

<br>


*Examples:*

## Request
 `POST /locations/neary`
``` 
{
  "latitude": 37.423021,
  "longitude": -122.083739,
  "category": ""
}
```

## ConsoleApp message if response is success
![](https://i.imgur.com/wmwbYFX.png)
