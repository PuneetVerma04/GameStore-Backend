#Game Store API

## Starting SQL Server

```powershell
$sa_password = "[SA Password Here]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the conncetion string to secret manager

```powershell
$sa_password = "[SA Password Here]"
dotnet user-secrets set "ConnectionStrings:GameStoreDb" "Server=localhost ;Database=GameStore;User Id=sa;Password=$sa_password;TrustServerCertificate=True;"
```
