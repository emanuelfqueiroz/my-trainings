USE [BlueMine]
GO

/****** Object:  Trigger [dbo].[tgTarefaHistorico]    Script Date: 09/06/2019 11:29:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER trigger [dbo].[tgTarefaHistorico]
ON [dbo].[Tarefa]
AFTER INSERT , UPDATE
AS
	insert into TarefaHistorico (TarefaId, Situacao, UsuarioId)
	select TarefaId, Situacao, UsuarioId From inserted
GO


