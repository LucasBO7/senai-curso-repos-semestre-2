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

Nome do usu�rio
Tipo do usu�rio
Data do evento
Local do evento (Institui��o)
Tipo do evento
Nome do evento
Descri��o do evento
Situa��o do evento
Coment�rio do evento
--------------------------------

Infos usu�rio
Infos Evento
Infos Instituicao
Situacao Presenca
Comentario
*/

SELECT
	Usuario.Nome AS 'Nome do usu�rio',
	TiposDeUsuario.TituloTipoUsuario AS 'Tipo de Usu�rio',
	Evento.DataEvento AS 'Data do evento',
	Instituicao.NomeFantasia + ' | ' + Instituicao.Endereco AS 'Endere�o do evento', -- CONCAT(NomeFantasia, ' | ', Endereco)
	Evento.Nome AS 'Nome do evento',
	Evento.Descricao AS 'Descri��o do evento',
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmado' ELSE 'Pendente' END AS 'Situa��o da presen�a',
	Comentario.Descricao AS 'Coment�rio'
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