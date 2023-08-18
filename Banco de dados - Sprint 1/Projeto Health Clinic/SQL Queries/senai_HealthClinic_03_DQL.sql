-- DQL: Data Query Language

-- Entrar no banco de dados
USE HealthClinic;


-- Pesquisas personalizadas

SELECT
	Consulta.IdConsulta AS 'Id da Consulta',
	Consulta.Data 'Dia da Consulta',
	Consulta.Horario 'Hor�rio da Consulta',
	Clinica.NomeFantasia AS 'Nome da Cl�nica',
	[Nome Paciente].Nome AS 'Nome do usu�rio',
	[Nome Medico].Nome AS 'Nome do m�dico',
	Especializacao.Nome AS 'Especialidade m�dica',
	Medico.CRM AS 'CRM do m�dico',
	Consulta.Prontuario AS 'Prontu�rio',
	Feedback.Descricao AS 'Coment�rios'

FROM
	Medico
INNER JOIN Clinica
ON Medico.IdClinica = Clinica.IdClinica
INNER JOIN Consulta
ON Medico.IdMedico = Consulta.IdMedico
INNER JOIN Paciente
ON Consulta.IdPaciente = Paciente.IdPaciente
INNER JOIN Usuario AS [Nome Paciente]
ON Paciente.IdUsuario = [Nome Paciente].IdUsuario
INNER JOIN Usuario AS [Nome Medico]
ON Medico.IdUsuario = [Nome Medico].IdUsuario
INNER JOIN Especializacao
ON Medico.IdEspecializacao = Especializacao.IdEspecializacao
LEFT JOIN Feedback -- retorna os que tiverem ou n�o coment�rios
ON Consulta.IdFeedback = Feedback.IdFeedback;
--SUBSELECT


-- Criar fun��o para retornar os m�dicos de uma determinada especialidade

CREATE FUNCTION FiltrarMedicosPorEspecialidade
(
	@especialidade VARCHAR(80)
)
RETURNS TABLE
AS
RETURN
(
	SELECT
		Usuario.Nome AS 'Nome do M�dico',
		Especializacao.Nome AS 'Especializa��o'
	FROM
		Especializacao
	INNER JOIN Medico
	ON Medico.IdEspecializacao = Especializacao.IdEspecializacao
	INNER JOIN Usuario
	ON Usuario.IdUsuario = Medico.IdUsuario
	WHERE Especializacao.Nome = @especialidade
);

-- Execu��o do m�todo de Busca de M�dicos por especialidade: FiltrarMedicosPorEspecialidade
SELECT *
FROM FiltrarMedicosPorEspecialidade('cardiologista');


-- Criar procedure para retornar a idade de um determinado usu�rio espec�fico
CREATE PROCEDURE BuscarIdadeUsuario
@nomeUsuario VARCHAR(50)
AS
BEGIN
	-- Declara��o da vari�vel que receber� a data de nascimento do usu�rio pesquisado
	DECLARE @ano INT

	-- Busca a data de nascimento do usu�rio pesquisado e armazena na vari�vel @ano
	SELECT @ano = YEAR(Usuario.DataNascimento)
	FROM Usuario
	WHERE Usuario.Nome = @nomeUsuario

	-- Vari�vel que recebe o ano atual
	DECLARE @anoAtual INT = YEAR(GETDATE());

	-- Calcula a idade do usu�rio
	DECLARE @idadePesquisada INT = @anoAtual - @ano
	PRINT 'A idade do usu�rio ' + CAST(@nomeUsuario AS VARCHAR(50)) + ' �: ' + CAST(@idadePesquisada AS VARCHAR(50));
END;

EXEC BuscarIdadeUsuario 'Giulia Santos';



SELECT * FROM Clinica;
SELECT * FROM Consulta;
SELECT * FROM Especializacao;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Usuario;
SELECT * FROM Feedback;