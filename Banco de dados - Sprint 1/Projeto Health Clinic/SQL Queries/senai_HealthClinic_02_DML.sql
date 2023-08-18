-- DML: Data Manipulation Language

-- Entrar no banco de dados
USE HealthClinic;


-- Inserir dados nas tabelas

INSERT INTO Especializacao(Nome) VALUES('Cardiologista'), ('Otorrinolaringologista');

INSERT INTO Usuario(Email, Senha, Nome, DataNascimento) VALUES('doutorjon@gmail.com', 'doutorjon123', 'Elton Jon', '1989-02-03'), 
('giu@gmail.com', 'giu123', 'Giulia Santos', '2007-06-10'), 
('doutoramel@gmail.com', 'doutoramel123', 'Mel Eduarda', '04-02-2003'), ('carlos', 'carlos123', 'Carlos Costa', '1989-05-08');

INSERT INTO Clinica(CPNJ, NomeFantasia, RazaoSocial, HorarioAbertura, HorarioFechamento, Endereco) VALUES 
('91.861.423/0001-51', 'HelathClinic', 'Rede Health''s Life', '04:00', '02:00', 'Rua engenheiro Garcia, 258 - SCS');

INSERT INTO Paciente(IdUsuario, Altura, Peso) VALUES (1, 1.64, 63), (4, 1.70, 63);

INSERT INTO Medico(IdClinica, IdEspecializacao, IdUsuario, CRM, NumeroCelular) VALUES(1, 2, 1, '932184/SP', '+55 (11) 95684-5521'), 
(1, 1, 3, '123456/SP', '+55 (11) 95684-5521');

INSERT INTO Feedback(IdPaciente, Titulo, Descricao) VALUES(1, 'Excelente!!', 'Médico extremamente profissional!');

INSERT INTO Consulta(IdMedico, IdFeedback, IdPaciente, Data, Horario, Prontuario) VALUES(1, 1, 1, '10-08-2023', '10:05:00', 'Este é um prontuário..');
INSERT INTO Consulta(IdMedico, IdPaciente, Data, Horario, Prontuario) VALUES(1, 1, '15-03-2023', '15:20:00', 'Este é um outro prontuário..');