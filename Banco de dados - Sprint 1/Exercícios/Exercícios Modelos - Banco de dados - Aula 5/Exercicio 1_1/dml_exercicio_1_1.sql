-- DML: Manipulação de dados

-- User banco de dados
USE Exercicio_1_1

-- Inserir dados
INSERT INTO Pessoa(Nome, CNH) VALUES('Lucas Bianchezzi Oliveira', '123456789'), ('john ksd', '234574557'), ('Tebes', '522684579');

-- Inserir dados Email
INSERT INTO Email(IdPessoa, Endereco) VALUES (1, 'lucas@email.com'), (2, 'john@email.com'), (3, 'teb@email.com');
INSERT INTO Email(IdPessoa, Endereco) VALUES (1, 'lucas_secundaria@email.com');

-- Inserir dados Telefone
INSERT INTO Telefone(IdPessoa, Numero) 
VALUES (1, '+55 (11) 96512-1248'), (2, '+55 (11) 95842-2674'), (3, '+55 (11) 48567-1534');

SELECT * FROM Pessoa;
SELECT * FROM Email;
SELECT * FROM Telefone;