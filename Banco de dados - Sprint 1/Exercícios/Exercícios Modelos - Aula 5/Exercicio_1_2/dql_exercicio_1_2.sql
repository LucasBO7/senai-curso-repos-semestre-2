-- DQL: Consulta


USE Exercicio_1_2;

SELECT * FROM Aluguel;
SELECT * FROM Veiculo;
SELECT * FROM Cliente;
SELECT * FROM Modelo;
SELECT * FROM Empresa;
SELECT * FROM Marca;

-- listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro
SELECT
	Aluguel.DataRetirada AS 'Data de retirada',
	Aluguel.DataDevolucao AS 'Data de devolução',
	Cliente.Nome AS 'Nome do cliente',
	Modelo.Nome AS 'Modelo do carro'
FROM 
	Aluguel
INNER JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Veiculo
ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo
ON Veiculo.IdModelo = Modelo.IdModelo;

-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT
	Cliente.Nome AS 'Nome do cliente',
	Aluguel.DataRetirada AS 'Data de retirada',
	Aluguel.DataDevolucao AS 'Data de devolução',
	Modelo.Nome AS 'Modelo do carro'
FROM
	Aluguel
INNER JOIN Cliente
ON Aluguel.IdCliente = Cliente.IdCliente
INNER JOIN Veiculo
ON Aluguel.IdVeiculo = Veiculo.IdVeiculo
INNER JOIN Modelo
ON Veiculo.IdModelo = Modelo.IdModelo

WHERE Cliente.Nome = 'Carol';
