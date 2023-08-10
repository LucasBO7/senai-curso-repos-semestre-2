-- DQL: Cria��o

USE Exercicio_1_3;


-- listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
SELECT 
	Veterinario.Nome
FROM
	Veterinario;


-- listar todas as ra�as que come�am com a letra S
SELECT
	Raca.Nome
FROM
	Raca
WHERE
	Raca.Nome LIKE 'S%';


-- listar todos os tipos de pet que terminam com a letra O
SELECT
	Tipo.Nome
FROM
	Tipo
WHERE
	Tipo.Nome LIKE '%o';


-- listar todos os pets mostrando os nomes dos seus donos
SELECT
	Pet.Nome AS 'Nome do pet',
	Pet.DataNascimento AS 'Data de nascimento do pet',
	Dono.Nome AS 'Nome do dono'
FROM
	DonoPet
INNER JOIN Pet
ON DonoPet.IdPet = Pet.IdPet
INNER JOIN Dono
ON DonoPet.IdDono = Dono.IdDono;


-- listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e o nome da cl�nica onde o pet foi atendido
SELECT
	Veterinario.Nome AS Veterin�rio,
	Pet.Nome AS Pet,
	Raca.Nome AS 'Ra�a do pet',
	Tipo.Nome AS 'Tipo do pet',
	Dono.Nome AS 'Dono do pet',
	Clinica.Nome AS Cl�nica
FROM
	Atendimento
INNER JOIN Veterinario
ON Atendimento.IdVeterinario = Veterinario.IdVeterinario
INNER JOIN Pet
ON Atendimento.IdPet = Pet.IdPet
INNER JOIN Raca
ON Pet.IdRaca = Raca.IdRaca
INNER JOIN Tipo
ON Pet.IdTipo = Tipo.IdTipo

INNER JOIN DonoPet
ON Pet.IdPet = DonoPet.IdPet
INNER JOIN Dono
ON Dono.IdDono = DonoPet.IdDono

INNER JOIN Clinica
ON Veterinario.IdClinica = Clinica.IdClinica;