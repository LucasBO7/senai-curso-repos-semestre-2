-- DDL: Criar banco e tabelas

-- Cria banco
CREATE DATABASE Exercicio_1_1;

-- Entrar no banco criado: Exercicio_1_1
USE Exercicio_1_1;

-- Criar tabelas
CREATE TABLE Pessoa
(
	IdPessoa INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
	CNH VARCHAR(11) NOT NULL UNIQUE
);

CREATE TABLE Telefone
(
	IdTelefone INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoa(IdPessoa) NOT NULL,
	Numero VARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE Email
(
	IdEmail INT PRIMARY KEY IDENTITY,
	IdPessoa INT FOREIGN KEY REFERENCES Pessoa(IdPessoa) NOT NULL,
	Endereco VARCHAR(30) NOT NULL UNIQUE
);



-- DQL: Consulta de dados

SELECT * FROM Pessoa;
SELECT * FROM Telefone;
SELECT * FROM Email;