-- DML: Data Manipulation Language

-- Entrar no banco de dados
USE HealthClinic;


-- Inserir dados nas tabelas

INSERT INTO Especializacao(Nome) VALUES('Cardiologista'), ('Otorrinolaringologista');

INSERT INTO Usuario(Email, Senha, Nome) VALUES('doutorjon@gmail.com', 'doutorjon123', 'Elton Jon'), ('giu@gmail.com', 'giu123', 'Giulia Santos');

INSERT INTO Clinica(CPNJ, NomeFantasia, RazaoSocial, HorarioAbertura, HorarioFechamento, Endereco) VALUES ('91.861.423/0001-51', 'HelathClinic', 'Rede Health''s Life', '04:00', '02:00', 'Rua engenheiro Garcia, 258 - SCS');

INSERT INTO Paciente(IdUsuario, Altura, Peso, DataNascimento) VALUES(2, 1.71, 57, '10-06-2007');

INSERT INTO Medico(IdClinica, IdEspecializacao, IdUsuario, Nome, NumeroCelular) VALUES(1, 2, 1, '+55 (11) 95684-5521');

INSERT INTO Feedback(IdPaciente, Descricao) VALUES(1, 'Médico extremamente profissional!');