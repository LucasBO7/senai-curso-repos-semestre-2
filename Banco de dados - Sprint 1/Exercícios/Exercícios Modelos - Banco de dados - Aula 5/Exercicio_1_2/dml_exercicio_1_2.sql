-- DML: manipula��o de dados

-- Inser��o de dados - EMPRESA
INSERT INTO Empresa(Nome, Cnpj)
VALUES ('Bayerische Motoren', 252687995321), ('Mazda Motor Corporation', 135567891011);


-- Inser��o de dados - CLIENTE
INSERT INTO Cliente(Nome, Cpf, NumeroCelular)
VALUES ('Carol', 25368460877, '+55 (11) 96702-8369'),
('Josu�', 34552385452, '+55 (11) 24455-1225');


-- Inser��o de dados - MARCA
INSERT INTO Marca(Nome)
VALUES ('BMW'),
('Mazda');

-- Inser��o de dados - MODELO
INSERT INTO Modelo(Nome)
VALUES ('RX7'),
('320I'),
('MX5');


-- Inser��o de dados - VEICULO
INSERT INTO Veiculo(IdMarca, IdModelo, IdEmpresa, Placa)
VALUES (1, 2, 1, 'ABC0012'),
(2, 1, 2, 'BFR1502'),
(2, 3, 2, 'HJE5283');


-- Inser��o de dados - ALUGUEL
INSERT INTO Aluguel(IdCliente, IdVeiculo, Codigo, Duracao, DataRetirada, DataDevolucao)
VALUES (1, 1, '0ff0f0f0f#1', CONVERT(TIME, '02:20:45'), CONVERT(DATE, '2023-02-20'), CONVERT(DATE, '2023-02-20')),
(2, 1, '0ff0f0f0f#2', CONVERT(TIME, '02:20:45'), CONVERT(DATE, '2023-02-20'), CONVERT(DATE, '2023-02-20')),
(1, 1, '0ff0f0f0f#3', CONVERT(TIME, '10:25:05'), CONVERT(DATE, '2023-02-20'), CONVERT(DATE, '2023-02-20')),
(2, 1, '0ff0f0f0f#4', CONVERT(TIME, '20:25:05'), CONVERT(DATE, '2023-02-22'), CONVERT(DATE, '2023-02-23'));



SELECT * FROM Cliente;
SELECT * FROM Empresa;
SELECT * FROM Marca;
SELECT * FROM Modelo;
SELECT * FROM Veiculo;
SELECT * FROM Aluguel;