-- DQL: Consulta

USE Exercicio_1_1;

-- SCRIPT SEM JOIN

-- Seleciona somente as propriedades inseridas ao lado do SELECT
SELECT 
	P.Nome AS Usuário,
	Telefone.Numero AS Telefone,
	Email.Endereco AS 'Endereço de email',
	P.CNH AS 'Número do CNH'

FROM -- Indica de quais tabelas são essas propriedades
	Pessoa AS P, 
	Email,
	Telefone

WHERE
	P.IdPessoa = Email.IdPessoa
	AND P.IdPessoa = Telefone.IdPessoa
ORDER BY
	Nome DESC 
-- DESC: descendente, indica que está na ordem decrescente
-- Para dar apelidos para as colunas, servindo para que a consulta da tabela, tenha as colunas com o  
-- apelido dado. Basta usar no formato: Propriedade AS apelidoDesejado

INSERT INTO Pessoa VALUES('José', '64353224'),
('João', '45762224'),
('Emanuel', '98343224'),
('Letícia', '34553621');

SELECT *
FROM 
	PESSOA,
	Email,
	Telefone;

INSERT INTO Pessoa VALUES('Artur', '12343214');
INSERT INTO Email VALUES(3, 'artur@email.com');
INSERT INTO Telefone VALUES(3, '11987675433');