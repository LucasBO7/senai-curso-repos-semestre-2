-- DDL: Data Definition Language

--	CRIA BANCO DE DADOS
CREATE DATABASE BancoAprendizado;

-- INDICA QUE 
USE BancoAprendizado;

-- CRIA A TABELA
CREATE TABLE Funcionarios
(
	IdFuncionario INT PRIMARY KEY IDENTITY,
	-- IDENTITY = Comando para indicar que aquela propriedade é um Id, sendo gerada automaticamente
	Nome VARCHAR(10)
);


CREATE TABLE Empresas
(
	IdEmpresa INT PRIMARY KEY IDENTITY,
	IdFuncionario INT FOREIGN KEY REFERENCES Funcionarios(IdFuncionario),
	Nome VARCHAR(20)
);

-------------------------------------

-- Alterar tabela (adiciona)
ALTER TABLE Funcionarios
ADD Cpf VARCHAR(11);

-- Alterar tabela (remove)
ALTER TABLE Funcionarios
DROP COLUMN Cpf;

-- Deleta/remove a tabela Empresas
DROP TABLE Empresas;

-- Deleta/remove o banco de dados inteiro
DROP DATABASE BancoAprendizado;