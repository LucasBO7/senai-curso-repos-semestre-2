-- DDL Exercicio 1_6

-- Criar Banco de dados

CREATE DATABASE Exercicio_1_6;

-- Entrar no banco de dados
USE Exercicio_1_6;

CREATE TABLE Tipo
(
	IdTipo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30) NOT NULL
);

CREATE TABLE Equipamento
(
	IdEquipamento INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(30) NOT NULL,
	Defeito VARCHAR(8000)
);

CREATE TABLE Cliente
(
	IdCliente INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Colaborador
(
	IdColaborador INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50) NOT NULL,
	Expediente VARCHAR(12) NOT NULL,
	Salario DECIMAL NOT NULL
);

CREATE TABLE Servico
(
	IdServico INT PRIMARY KEY IDENTITY,
	IdTipo INT FOREIGN KEY REFERENCES Tipo(IdTipo) NOT NULL,
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente) NOT NULL,
	IdEquipamento INT FOREIGN KEY REFERENCES Equipamento(IdEquipamento) NOT NULL,
	ValorTotal DECIMAL NOT NULL,
	[Data] DATE NOT NULL
);


CREATE TABLE ColaboradorServico
(
	IdColaboradorServico INT PRIMARY KEY IDENTITY,
	IdColaborador INT FOREIGN KEY REFERENCES Colaborador(IdColaborador) NOT NULL,
	IdServico INT FOREIGN KEY REFERENCES Servico(IdServico) NOT NULL,
);