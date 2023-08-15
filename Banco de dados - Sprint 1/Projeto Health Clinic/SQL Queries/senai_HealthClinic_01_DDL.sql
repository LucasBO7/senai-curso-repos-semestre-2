-- DDL: Data Definition Language

-- Criar bd
CREATE DATABASE [HealthClinic];

-- abrir bd
USE [HealthClinic];

-- Criar tabelas


CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	CPNJ VARCHAR(20) NOT NULL,
	NomeFantasia VARCHAR(50),
	RazaoSocial VARCHAR(60) NOT NULL,
	HorarioAbertura DATE NOT NULL,
	HorarioFechamento DATE NOT NULL,
	Endereco VARCHAR(150) NOT NULL
);
--SELECT * FROM Clinica;
/*	Inserir se houver escalabilidade
CREATE TABLE Endereco
(
	IdEndereco INT PRIMARY KEY IDENTITY,
	Endereco VARCHAR(50) NOT NULL,
	Bairro VARCHAR(25) NOT NULL,
	Numero INT NOT NULL
);*/



CREATE TABLE Especializacao
(
	IdEspecializacao INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(40) NOT NULL
);
--SELECT * FROM Especializacao;



CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(50) NOT NULL,
	Senha VARCHAR(20) NOT NULL,
	Nome VARCHAR(60) NOT NULL,
	DataNascimento DATE NOT NULL
);
--SELECT * FROM Usuario;



CREATE TABLE Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	Altura DECIMAL(3, 2),
	Peso DECIMAL(4, 2),
	Doencas VARCHAR(200)
);
--SELECT * FROM Paciente;



CREATE TABLE Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica) NOT NULL,
	IdEspecializacao INT FOREIGN KEY REFERENCES Especializacao(IdEspecializacao) NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	NumeroCelular VARCHAR(25) NOT NULL
);
--SELECT * FROM Medico;



CREATE TABLE Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico) NOT NULL,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	Data DATE NOT NULL,
	Prontuario VARCHAR(MAX) NOT NULL
);
--SELECT * FROM Consulta;



CREATE TABLE Feedback
(
	IdFeedback INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente) NOT NULL,
	Titulo VARCHAR(150) NOT NULL,
	Descricao VARCHAR(400) NOT NULL
);