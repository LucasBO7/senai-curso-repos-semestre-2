-- DML: manipulação de dados

-- Inserção de dados - EMPRESA
INSERT INTO Empresa(Nome, Cnpj)
VALUES ('Bayerische Motoren', 252687995321), ('Mazda Motor Corporation', 135567891011);


-- Inserção de dados - CLIENTE
INSERT INTO Cliente(Nome, Cpf, NumeroCelular)
VALUES ('Carol', 25368460877, '+55 (11) 96702-8369'),
('Josué', 34552385452, '+55 (11) 24455-1225');


-- Inserção de dados - MARCA
INSERT INTO Marca(Nome)
VALUES ('BMW'),
('Mazda');

-- Inserção de dados - MODELO
INSERT INTO Modelo(Nome)
VALUES ('RX7'),
('320I'),
('MX5');


-- Inserção de dados - VEICULO
INSERT INTO Veiculo(IdMarca, IdModelo, IdEmpresa, Placa)
VALUES (1, 2, 1, 'ABC0012'),
(2, 1, 2, 'BFR1502'),
(2, 3, 2, 'HJE5283');


-- Inserção de dados - ALUGUEL
--INSERT INTO Aluguel(IdCliente, IdVeiculo, Codigo, Duracao, [Data])
--VALUES (1, 1, '0ff0f0f0f#1', 02:20:25, 20/05/2023),
--(2, 3, '0ff0f0f0f#2', 06:43:53, 22/05/2023);



SELECT * FROM Cliente;
SELECT * FROM Empresa;
SELECT * FROM Marca;
SELECT * FROM Modelo;
SELECT * FROM Veiculo;