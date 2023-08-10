-- DML: Data Manipulation Language

-- Insere um funcionário
INSERT INTO Funcionarios(Nome)
VALUES ('VITÓRIA');

-- Altera um Funcionário
UPDATE Funcionarios
SET Nome = 'Vitória' WHERE Nome = 'VITÓRIA';

-- Insere uma empresa
INSERT INTO Empresas(IdFuncionario, Nome)
VALUES(3, 'MicTech');