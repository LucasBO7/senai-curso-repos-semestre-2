-- DML: Manipula��o de dados


-- Inser��o banco de dados Cl�nica
INSERT INTO Clinica(Nome, Endereco, Telefone) VALUES('Paw&Pet', 'Rua Arnaldo 185 - SBC', '+55 (11) 96552-8361');

-- O Expediente est� em horas.
INSERT INTO Veterinario(IdClinica, Nome, Expediente) VALUES(1, 'Jonas', '10:00');


SELECT * FROM Clinica;
SELECT * FROM Veterinario;