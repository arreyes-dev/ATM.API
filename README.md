# ATM.API - Entorno de Base de Datos Temporal (SQL Server + Docker)

Este proyecto incluye un entorno Docker para levantar una instancia temporal de SQL Server y ejecutar scripts SQL de forma manual. Útil para desarrollo, pruebas o poblado inicial de datos.

---

## 📁 Estructura relevante

```
src/
└── ATM.API.Infrastructure/
└── Container/
├── docker-compose.yml
├── 01-create-tables.sql
├── 02-seed-data.sql
└── sql-scripts/
````

---

## 🚀 Pasos para ejecutar la base de datos

### 1. Iniciar SQL Server con Docker

Desde la carpeta:

```bash
cd src/ATM.API.Infrastructure/Container
docker-compose up -d
````

Esto levantará una instancia de SQL Server con los datos persistidos en un volumen local.

---

### 2. Conectarse al contenedor e ingresar comandos manualmente

Ejecuta el siguiente comando para abrir una sesión de `sqlcmd` dentro del contenedor:

```bash
docker exec -it <nombre_del_contenedor> /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd
```

> 🔁 **¿No sabes el nombre del contenedor?**
> Usa `docker ps` para verlo. Ejemplo: `atm-db` o `sqlserver-dev`.

---

### 3. Ejecutar manualmente los scripts SQL

Una vez dentro de `sqlcmd`, puedes ejecutar los queries:

```sql
01-create-tables.sql
02-seed-data.sql
```
---

## 🧪 Verificar los datos

Ejecuta una consulta desde fuera del contenedor:

```bash
docker exec -it <nombre_del_contenedor> /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P YourStrong@Passw0rd -Q "USE BankingDb; SELECT * FROM Customers; SELECT * FROM BankAccounts;"
```

---

## ⚙️ Credenciales por defecto

* **Usuario:** `sa`
* **Contraseña:** `YourStrong@Passw0rd`
* **Base de datos:** `BankingDb`

---

## 🧹 Detener y eliminar el contenedor

```bash
docker-compose down
```

---

## 📌 Notas

* Si los scripts fallan al ejecutar automáticamente, verifica que el contenedor esté 100% iniciado (`docker logs <container>`).

