USE BankingDb;
GO

-- Insertar clientes
INSERT INTO Customers (DNI, Name, LastName)
VALUES 
('12345678A', 'Juan', 'Pérez'),
('87654321B', 'María', 'Gómez'),
('11223344C', 'Carlos', 'López');
GO

-- Insertar cuentas bancarias
INSERT INTO BankAccounts (AccountNumber, Balance, CustomerId)
VALUES 
(100001, 1500.00, 1),
(100002, 2500.50, 1),
(200001, 5000.75, 2),
(300001, 10000.00, 3);
GO