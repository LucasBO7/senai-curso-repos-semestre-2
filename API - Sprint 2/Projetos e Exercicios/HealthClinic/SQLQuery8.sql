SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Consulta;
SELECT * FROM Comentario;

INSERT INTO Clinica(IdClinica, CNPJ, NomeFantasia, RazaoSocial, HorarioAbertura, HorarioFechamento, Endereco) 
VALUES(NEWID(), '24563258878', 'Clinica Saúde e CIA', 'José Sias', '10:00:00', '18:00:00', 'Rua Simon Julio - 286');

INSERT INTO Especializacao(IdEspecializacao, Nome) VALUES(NEWID(), 'Cardiologista');

INSERT INTO Medico(IdMedico, IdClinica, IdEspecializacao, IdUsuario, CRM, NumeroCelular) 
VALUES(NEWID(), 'B48E2E5E-9A7B-42F2-B1B7-F38F9BB1E802', 'AF7F273D-279F-444D-B9DA-31AA64332235', '3DA73535-17EE-449F-B2F4-D5BD16AFEB8A', '12516332', '952562257');


INSERT INTO Paciente(IdPaciente, IdUsuario, CPF, RG, DataNascimento)
VALUES(NEWID(), '3DA73535-17EE-449F-B2F4-D5BD16AFEB8A', '21544487566', '1234567', '20-06-2007');

INSERT INTO Comentario(IdComentario, IdPaciente, Descricao, Status) 
VALUES(NEWID(), '780EAB48-7EE0-41F9-9C78-033BFB6057AA', 'Sla krl', 1);

INSERT INTO Consulta(IdConsulta, IdMedico, IdFeedback, IdPaciente, [Data], Prontuario)
VALUES(NEWID(), '23B8C79E-6917-404C-8CBD-DC3E854E678B', 'FE76A199-6E00-4F26-B709-418BD2208247', '780EAB48-7EE0-41F9-9C78-033BFB6057AA', '23-06-2010', 'Prontuário pronto com sucesso');