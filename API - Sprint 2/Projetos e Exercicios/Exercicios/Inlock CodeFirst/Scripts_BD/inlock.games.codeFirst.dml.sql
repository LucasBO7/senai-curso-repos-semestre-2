-- DML: Data Manipulation Language

INSERT INTO Estudio(IdEstudio, Nome) VALUES (NEWID() , 'Blizzard'),(NEWID(), 'Rockstar Studios'),(NEWID(), 'Square Enix');

INSERT INTO Jogo VALUES 
(NEWID(),'Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.','2012-09-24', 99.00, '130422EB-525A-4935-AB8A-04D0ACF85148'),
(NEWID(),'Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','2012-09-27', 12.00, '130422EB-525A-4935-AB8A-04D0ACF85148');
SELECT * FROM Jogo

INSERT INTO TiposUsuario VALUES (NEWID(), 'Comum'),(NEWID(), 'Administrador');
SELECT * FROM TiposUsuario;

INSERT INTO Usuario VALUES 
(NEWID(),'cliente@cliente.com','cliente', 'F0D688F9-5C4E-48B9-BB84-5EB51AE1A136'),
(NEWID(),'admin@admin.com','admin', 'F012C6C7-E0B1-4A43-AD5F-DF4042E1F688');
SELECT * FROM Usuario;