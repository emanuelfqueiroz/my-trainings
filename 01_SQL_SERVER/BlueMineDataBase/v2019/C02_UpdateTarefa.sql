Update Tarefa set  Situacao = 'E'
WHere TarefaId in (Select MAX(TarefaId) From Tarefa Group by UsuarioId)

-- Consulte o hitórico das tarefas alteradas:
Select * From TarefaHistorico 
where TarefaId = SOME(Select TarefaId From TarefaHistorico where Situacao = 'E')


--- Você poderá visualizar o histórico de todas as inserções e updates com o select abaixo:
Select * From TarefaHistorico 