SELECT * FROM TiposUsuarios;
SELECT * FROM Usuarios;
SELECT * FROM Instituicoes;
SELECT * FROM TiposEventos;
SELECT * FROM Eventos;
SELECT * FROM Presencas;


SELECT NomeUsuario [Usu�rio],TituloTipoUsuario Tipo,Email FROM Usuarios U
INNER JOIN TiposUsuarios TU
ON TU.IdTipoUsuario = U.IdTipoUsuario;

SELECT NomeUsuario [Usu�rio],TituloTipoUsuario Tipo,DataEvento [Data], NomeFantasia [Local],TituloTipoEvento Tema, NomeEvento Evento,Descricao,Situacao FROM Eventos E
INNER JOIN Presencas P
ON E.IdEvento = P.IdEvento
INNER JOIN TiposEventos TE
ON TE.IdTipoEvento = E.IdTipoEvento
INNER JOIN Instituicoes I
ON E.IdInstituicao = I.IdInstituicao
INNER JOIN Usuarios U
ON U.IdUsuario = P.IdUsuario
INNER JOIN TiposUsuarios TU
ON TU.IdTipoUsuario = U.IdTipoUsuario;