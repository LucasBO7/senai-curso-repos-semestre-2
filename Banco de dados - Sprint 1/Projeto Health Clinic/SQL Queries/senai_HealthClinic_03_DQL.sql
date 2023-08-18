-- DQL: Data Query Language

-- Entrar no banco de dados
USE HealthClinic;


-- Pesquisas personalizadas

SELECT
	Consulta.IdConsulta AS 'Id da Consulta',
	Consulta.Data 'Dia da Consulta',
	Consulta.Horario 'Horário da Consulta',
	Clinica.NomeFantasia AS 'Nome da Clínica',
	[Nome Paciente].Nome AS 'Nome do usuário',
	[Nome Medico].Nome AS 'Nome do médico',
	Especializacao.Nome AS 'Especialidade médica',
	Medico.CRM AS 'CRM do médico',
	Consulta.Prontuario AS 'Prontuário',
	Feedback.Descricao AS 'Comentários'

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
LEFT JOIN Feedback -- retorna os que tiverem ou não comentários
ON Consulta.IdFeedback = Feedback.IdFeedback;
--SUBSELECT


-- Criar função para retornar os médicos de uma determinada especialidade

CREATE FUNCTION FiltrarMedicosPorEspecialidade
(
	@especialidade VARCHAR(80)
)
RETURNS TABLE
AS
RETURN
(
	SELECT
		Usuario.Nome AS 'Nome do Médico',
		Especializacao.Nome AS 'Especialização'
	FROM
		Especializacao
	INNER JOIN Medico
	ON Medico.IdEspecializacao = Especializacao.IdEspecializacao
	INNER JOIN Usuario
	ON Usuario.IdUsuario = Medico.IdUsuario
	WHERE Especializacao.Nome = @especialidade
);

-- Execução do método de Busca de Médicos por especialidade: FiltrarMedicosPorEspecialidade
SELECT *
FROM FiltrarMedicosPorEspecialidade('cardiologista');


-- Criar procedure para retornar a idade de um determinado usuário específico
CREATE PROCEDURE BuscarIdadeUsuario
@nomeUsuario VARCHAR(50)
AS
BEGIN
	-- Declaração da variável que receberá a data de nascimento do usuário pesquisado
	DECLARE @ano INT

	-- Busca a data de nascimento do usuário pesquisado e armazena na variável @ano
	SELECT @ano = YEAR(Usuario.DataNascimento)
	FROM Usuario
	WHERE Usuario.Nome = @nomeUsuario

	-- Variável que recebe o ano atual
	DECLARE @anoAtual INT = YEAR(GETDATE());

	-- Calcula a idade do usuário
	DECLARE @idadePesquisada INT = @anoAtual - @ano
	PRINT 'A idade do usuário ' + CAST(@nomeUsuario AS VARCHAR(50)) + ' é: ' + CAST(@idadePesquisada AS VARCHAR(50));
END;

EXEC BuscarIdadeUsuario 'Giulia Santos';



SELECT * FROM Clinica;
SELECT * FROM Consulta;
SELECT * FROM Especializacao;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Usuario;
SELECT * FROM Feedback;