-- DML: Data Manipulation Language

USE [Event+_Tarde];

-- Inserção de dados nas tabelas

/*
-- TiposDeUsuario
INSERT INTO TiposDeUsuario(TituloTipoUsuario) VALUES('Administrador'), ('Comum');

-- TiposDeEvento
INSERT INTO TiposDeEvento(TituloTipoEvento) VALUES('Palestra sobre SQL Server');

-- Instituicao
INSERT INTO Instituicao(CNPJ, Endereco, NomeFantasia) VALUES('13689012000117', 'Rua Niterói, 180 - São Caetano do Sul', 'Dev School');

-- Usuario
INSERT INTO Usuario(IdTipoDeUsuario, Nome, Email, Senha) VALUES(1, 'Lucas', 'lucas@gmail.com', 'lucas123');
INSERT INTO Usuario(IdTipoDeUsuario, Nome, Email, Senha) VALUES(1, 'LucasAdmin', 'lucas@admin.com', 'LucasAdmin123');

-- Evento
INSERT INTO Evento(IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HorarioEvento) VALUES(1, 2, 'SQL Server', 'Palestra sobre SQL Server e sua importância nos sistemas.', '2023-08-10', '10:30:00');
*/

-- PresencasEvento
INSERT INTO PresencasEvento(IdUsuario, IdEvento) VALUES(1, 2);

-- Comentario
INSERT INTO Comentario(IdUsuario, IdEvento, Descricao) VALUES(1, 2, 'Hoje abriremos as entradas para a palestra!');

SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM PresencasEvento;
SELECT * FROM Comentario;