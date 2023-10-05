SELECT * FROM Especializacao;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Consulta;
SELECT * FROM Comentario;
SELECT * FROM Clinica;
SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;

INSERT INTO Clinica(IdClinica, CNPJ, NomeFantasia, RazaoSocial, HorarioAbertura, HorarioFechamento, Endereco) 
VALUES(NEWID(), '24563258878', 'Clinica Saúde e CIA', 'José Sias', '10:00:00', '18:00:00', 'Rua Simon Julio - 286');

INSERT INTO Especializacao(IdEspecializacao, Nome) VALUES(NEWID(), 'Cardiologista');

INSERT INTO Medico(IdMedico, IdClinica, IdEspecializacao, IdUsuario, CRM, NumeroCelular) 
VALUES(NEWID(), 'B48E2E5E-9A7B-42F2-B1B7-F38F9BB1E802', 'AF7F273D-279F-444D-B9DA-31AA64332235', '3DA73535-17EE-449F-B2F4-D5BD16AFEB8A', '12516332', '952562257');


INSERT INTO Paciente(IdPaciente, IdUsuario, CPF, RG, DataNascimento)
VALUES(NEWID(), '19259862-5AEF-48F0-9EB7-041B8025A04B', '21544487566', '1234567', '20-06-2007');

INSERT INTO Comentario(IdComentario, IdPaciente, Descricao, Status) 
VALUES(NEWID(), '780EAB48-7EE0-41F9-9C78-033BFB6057AA', 'Sla krl', 1);

INSERT INTO Consulta(IdConsulta, IdMedico, IdPaciente, [Data], Prontuario)
VALUES(NEWID(), '6926CCCB-C72D-487C-BAA7-A8615A19781D', '6368BC32-A1BC-4595-A18F-AB5682C2269D', '23-06-2010', '');