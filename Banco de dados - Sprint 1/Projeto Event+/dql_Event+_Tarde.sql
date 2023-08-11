-- DQL: Data Query Language

SELECT * FROM Comentario;
SELECT * FROM Evento;
SELECT * FROM Instituicao;
SELECT * FROM PresencasEvento;
SELECT * FROM TiposDeEvento;
SELECT * FROM TiposDeUsuario;
SELECT * FROM Usuario;

/*
Usar JOIN

Nome do usuário
Tipo do usuário
Data do evento
Local do evento (Instituição)
Tipo do evento
Nome do evento
Descrição do evento
Situação do evento
Comentário do evento
--------------------------------

Infos usuário
Infos Evento
Infos Instituicao
Situacao Presenca
Comentario
*/

SELECT
	Usuario.Nome AS 'Nome do usuário',
	TiposDeUsuario.TituloTipoUsuario AS 'Tipo de Usuário',
	Evento.DataEvento AS 'Data do evento',
	Instituicao.NomeFantasia + ' | ' + Instituicao.Endereco AS 'Endereço do evento', -- CONCAT(NomeFantasia, ' | ', Endereco)
	Evento.Nome AS 'Nome do evento',
	Evento.Descricao AS 'Descrição do evento',
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Pendente' END AS 'Situação da presença',
	Comentario.Descricao AS 'Comentário'
FROM
	PresencasEvento
INNER JOIN Usuario
ON Usuario.IdUsuario = PresencasEvento.IdUsuario
INNER JOIN TiposDeUsuario
ON Usuario.IdTipoDeUsuario = TiposDeUsuario.IdTipoDeUsuario
INNER JOIN Evento
ON PresencasEvento.IdEvento = Evento.IdEvento
INNER JOIN Instituicao
ON Evento.IdInstituicao = Instituicao.IdInstituicao
RIGHT JOIN Comentario
ON Usuario.IdUsuario = Comentario.IdUsuario;