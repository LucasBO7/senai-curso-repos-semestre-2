-- DML: modificar os dados --> Exercicio_1_4

USE Exercicio_1_4;

INSERT INTO TipoPermissao(Nome) 
VALUES('Usu�rio comum'),
('Administrador');


INSERT INTO Usuario(IdTipoPermissao, Nome, Email, Senha)
VALUES(2, 'Chezzi', 'chezzi@gmail.com', 'chezziadm123'),
(1, 'Marcella', 'mah@gmail.com', 'mah123');

INSERT INTO Musica(Nome, Minutagem)
VALUES ('N�o quero mais cnvs', CONVERT(TIME, '02:45')),
('DAMN!', CONVERT(TIME, '02:20')),
('M�tico Jovem', CONVERT(TIME, '03:00'));


SELECT * FROM TipoPermissao;
SELECT * FROM Usuario;
SELECT * FROM Musica;