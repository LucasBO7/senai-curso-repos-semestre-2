-- DDL - Data Definition Language

-- criar o banco de dados
CREATE DATABASE [Event+_Tarde];
USE [Event+_Tarde];

-- criar as tabelas
CREATE TABLE TiposDeUsuario
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE TiposDeEvento
(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(200) NOT NULL,
	NomeFantasia VARCHAR(200) NOT NULL
);

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTipoDeUsuario),
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(50) NOT NULL
);

CREATE TABLE Evento
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TiposDeEvento(IdTipoDeEvento),
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	Nome VARCHAR(100) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	DataEvento DATE NOT NULL,
	HorarioEvento TIME NOT NULL
);

CREATE TABLE PresencasEvento
(
	IdPresencaEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Situacao BIT DEFAULT(0) NOT NULL
);

CREATE TABLE Comentario
(
	IdComentarioEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Descricao VARCHAR(200) NOT NULL,
	Exibe BIT DEFAULT(0) NOT NULL
);