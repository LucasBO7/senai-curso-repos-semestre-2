-- DML: Data Manipulation Language

-- Insere um funcion�rio
INSERT INTO Funcionarios(Nome)
VALUES ('VIT�RIA');

-- Altera um Funcion�rio
UPDATE Funcionarios
SET Nome = 'Vit�ria' WHERE Nome = 'VIT�RIA';

-- Insere uma empresa
INSERT INTO Empresas(IdFuncionario, Nome)
VALUES(3, 'MicTech');