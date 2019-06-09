
If OBJECT_ID('TarefaHistorico') is not null
	DROP TABLE TarefaHistorico;
If OBJECT_ID('Tarefa') is not null
	DROP TABLE Tarefa;
If OBJECT_ID('Equipe') is not null
	DROP TABLE Equipe;
If OBJECT_ID('Projeto') is not null
	DROP TABLE Projeto;
If OBJECT_ID('Usuario') is not null
	DROP TABLE USUARIO;
If OBJECT_ID('Cargo') is not null
	DROP TABLE Cargo;



If OBJECT_ID('Cliente') is not null
	DROP TABLE Cliente;

CREATE TABLE dbo.Usuario(
	UsuarioId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CPF char(11) NOT NULL,
	Nome varchar(100) NOT NULL,
	DataNascimento date NOT NULL,
	Fone varchar(20) NOT NULL,
	Email varchar(100) NOT NULL,
	Sexo char(1) NOT NULL,
	CargoId int not NULL,
	Situacao char(1) NOT NULL, -- Or tinyint
	DataCriacao DATE default(getdate())
)

CREATE TABLE dbo.Tarefa(
	TarefaId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Nome varchar(50) NOT NULL,
	Descricao varchar(200) NULL,
	Prioridade tinyint NOT NULL,
	Prazo smalldatetime NOT NULL,
	Situacao char(1) NOT NULL, --Poderia ser situacaoId referenciando uma tabela TarefaSituacao
	DataFinalizacao smalldatetime NULL,
	DataCriacao smalldatetime default(getdate()),
	ProjetoId int not null,
	UsuarioId int NULL
)
CREATE TABLE dbo.TarefaHistorico( -- Adicionaremos Temporal Table para registrar o historico de mudancas
	TarefaId int NOT null,
	DataRegistro smalldatetime default(getdate()) NOT NULL,
	Situacao char(1) NOT NULL,
	UsuarioId int NULL,
	CONSTRAINT PK_TarefaHistorico 
		PRIMARY KEY CLUSTERED (TarefaId, DataRegistro)  
)

CREATE TABLE dbo.Projeto(
	ProjetoId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ClienteId int not null,
	Nome varchar(50) NOT NULL,
	Prazo date NOT NULL,
	DataInicio date NOT NULL,
	DataFinalizacao date NULL,
	DataCriacao date default(getdate()),
	GerenteId int not null
)

CREATE TABLE dbo.Equipe(
	EquipeId int primary key identity(1,1),
	UsuarioId int,
	ProjetoId int,
)


Create Table Cliente (
	ClienteId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CPF char(11) NULL,
	CNPJ char(14) NULL,
	Nome varchar(100) NOT NULL,
	NomeFantasia varchar(100) NOT NULL,
	Fone1 varchar(20) NOT NULL,
	Fone2 varchar(20) NOT NULL,
	Email varchar(100) NOT NULL,
	Situacao char(1) NOT NULL,
	constraint ck_CPF_Ou_CNPJ  -- Permite OU CPF OU CNPJ - apenas um deve ser preenchido
        check (        (CPF is null or CNPJ is null) 
               and not (CPF is null and CNPJ is null) )
)


Create Table Cargo (
	CargoId int primary key identity(1,1),
	Cargo varchar(50) NOT NULL
)

-- CHAVES ESTRANGEIRAS

-- chaves estrangeiras contexto de projeto
ALTER TABLE [dbo].[Equipe]  WITH CHECK ADD  CONSTRAINT [FK_Equipe_Projeto] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projeto] ([ProjetoId])
GO
ALTER TABLE [dbo].[Equipe] CHECK CONSTRAINT [FK_Equipe_Projeto]
GO
ALTER TABLE [dbo].[Equipe]  WITH CHECK ADD  CONSTRAINT [FK_Equipe_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Equipe] CHECK CONSTRAINT [FK_Equipe_Usuario]
GO
ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Gerente_Projeto_Usuario] FOREIGN KEY([GerenteId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Gerente_Projeto_Usuario]
GO
ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_Projeto_Cliente] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([ClienteId])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_Projeto_Cliente]
GO

-- chaves estrangeiras contexto tarefa
ALTER TABLE [dbo].[Tarefa]  WITH CHECK ADD  CONSTRAINT [FK_Tarefa_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([UsuarioId])
GO
ALTER TABLE [dbo].[Tarefa] CHECK CONSTRAINT [FK_Tarefa_Usuario]
GO
ALTER TABLE [dbo].[TarefaHistorico]  WITH CHECK ADD  CONSTRAINT [FK_TarefaHistorico_Tarefa] FOREIGN KEY([TarefaId])
REFERENCES [dbo].[Tarefa] ([TarefaId])
GO
ALTER TABLE [dbo].[TarefaHistorico] CHECK CONSTRAINT [FK_TarefaHistorico_Tarefa]
GO

-- chaves estrangeiras contexto usuário
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Cargo] FOREIGN KEY([CargoId])
REFERENCES [dbo].[Cargo] ([CargoId])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Cargo]
GO
