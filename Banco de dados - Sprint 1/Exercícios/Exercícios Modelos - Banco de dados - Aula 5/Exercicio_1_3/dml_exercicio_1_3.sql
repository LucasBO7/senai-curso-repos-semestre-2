-- DML: Manipulação de dados

USE Exercicio_1_3;

-- Inserção banco de dados Clínica
INSERT INTO Clinica(Nome, Endereco, Telefone) VALUES('Paw&Pet', 'Rua Arnaldo 185 - SBC', '+55 (11) 96552-8361');
INSERT INTO Clinica(Nome, Endereco, Telefone) VALUES('Pets Paradise', 'Rua Paraíso 213 - SCS', '+55 (11) 92964-1121');

-- O Expediente está em horas.
INSERT INTO Veterinario(IdClinica, Nome, Expediente) VALUES(1, 'Jonas', CONVERT(TIME, '10:00:00')),
(1, 'Laura', CONVERT(TIME, '08:00:00'));

INSERT INTO Tipo(Nome)
VALUES('Cachorro'),
('Gato');

INSERT INTO Raca(Nome)
VALUES('Golden'),
('Vira lata');

INSERT INTO Pet(IdTipo, IdRaca, Nome, DataNascimento)
VALUES (1, 1, 'Theo', CONVERT(DATE, '2019-05-16')),
(1, 2, 'Johnson', CONVERT(DATE, '2021-06-22')),
(2, 2, 'Manuela', CONVERT(DATE, '2022-01-06'));

UPDATE Raca
SET Nome = 'Samara' WHERE Nome = 'Vira lata';


INSERT INTO Atendimento(IdVeterinario, IdPet, Descricao, Data)
VALUES (1, 1, 'Farpa na pata.', CONVERT(DATE, '2023-08-01')),
(8, 2, 'Exame rotineiro.', CONVERT(DATE, '2023-08-01')),
(8, 3, 'Exame rotineiro.', CONVERT(DATE, '2023-08-01'));

INSERT INTO Dono(Nome)
VALUES ('Lucas'),
('Vitória');

INSERT INTO DonoPet(IdPet, IdDono)
VALUES (1, 1),
(2, 2),
(3, 2);



SELECT * FROM Clinica;
SELECT * FROM Veterinario;
SELECT * FROM Tipo;
SELECT * FROM Raca;
SELECT * FROM Pet;
SELECT * FROM Atendimento;
SELECT * FROM Dono;
SELECT * FROM DonoPet;