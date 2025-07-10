```
docker-compose up
```

```
docker exec -it container /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd -Q "USE BankingDb; SELECT * FROM Customers; SELECT * FROM BankAccounts;"
```