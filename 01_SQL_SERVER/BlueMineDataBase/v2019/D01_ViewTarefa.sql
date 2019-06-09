Create View vTarefa AS (
	SELECT T.TarefaId
		  ,T.Nome
		  ,T.Prioridade
		  ,T.Prazo
		  ,T.Situacao
		  ,T.DataFinalizacao
		  ,T.DataCriacao
		  ,T.ProjetoId
		  ,T.UsuarioId
		  , P.Nome as NomeProjeto
		  , U.Nome as NomeUsuario
	  FROM dbo.Tarefa as T
	  Join dbo.Usuario as U on U.UsuarioId = T.UsuarioId 
	  join dbo.Projeto as P on P.ProjetoId = T.ProjetoId
  )

  -- Select * From vTarefa